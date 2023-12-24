using LearningApp.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;

namespace LearningApp.Web.Modules.Test
{
    [ApiController]
    [Route("api/v1/run-python-code")]
    public class Test : ControllerBase
    {
        [HttpPost]
        public IActionResult RunPythonCode([FromBody] string code)
        {
            // "i=3\nwhile(i>0):\n\tprint(i)\n\ti=i-1"

            /*code = @"
for i in range(5):
   print(i)
";*/
            // added new branch
            var result = ExecutePythonCode(code);

            return Ok(result);
        }


        static Response<string> ExecutePythonCode(string userCode)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "C:\\Python310\\python.exe", // python path
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(userCode);
                    }
                }

                /*using (StreamReader sr = process.StandardOutput)
                {
                    return sr.ReadToEnd();
                }*/

                // limit execution time
                using (StreamReader sr = process.StandardOutput)
                using (StreamReader err = process.StandardError)
                {
                    // Set a timeout for the process
                    if (!process.WaitForExit(milliseconds: 5000)) // Adjust the timeout as needed
                    {
                        // Process exceeded the timeout, handle accordingly
                        return new Response<string>(false, null, "Error: Execution timed out.");
                    }

                    // Check for errors in the standard error stream
                    string errorOutput = err.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        return new Response<string>(false, null, $"Error: {errorOutput}");
                    }

                    // Read the standard output
                    return new Response<string>(true, sr.ReadToEnd(), "Execution Successful");
                }
            }
        }
    }
}
