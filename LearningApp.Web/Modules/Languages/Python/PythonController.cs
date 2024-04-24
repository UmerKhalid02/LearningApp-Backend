using LearningApp.Application.DataTransferObjects.LanguagesDTO.Python;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Languages.Python
{
    [Route("api/v1/python")]
    public class PythonController : BaseController
    {
        private readonly IPythonService _pythonService;

        public PythonController(IPythonService pythonService)
        {
            _pythonService = pythonService;
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpPost("run-code")]
        public async Task<IActionResult> RunPythonCode([FromBody] PythonRequestDTO request) 
        {
            var response = await _pythonService.RunCode(request);
            return Ok(response);
        }



    }
}
