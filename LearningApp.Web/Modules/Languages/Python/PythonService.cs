using LearningApp.Application.DataTransferObjects.LanguagesDTO.Python;
using LearningApp.Application.DataTransferObjects.Shared;
using LearningApp.Application.Exceptions;
using Newtonsoft.Json;
using System.Text;

namespace LearningApp.Web.Modules.Languages.Python
{
    public class PythonService : IPythonService
    {
        public async Task<PythonResponseDTO> RunCode(PythonRequestDTO request)
        {
            string apiUrl = Vercel.BaseUrl + "execute-python-code";

            using (HttpClient client = new HttpClient())
            {
                var serializedRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                httpRequest.Content = content;

                var response = await client.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode) {

                    var result = await response.Content.ReadAsStringAsync();
                    var outputResponse = JsonConvert.DeserializeObject<PythonResponseDTO>(result);

                    if (outputResponse != null)
                        return outputResponse;

                    else
                        throw new InternalServerErrorException();
                }
            }

            throw new InternalServerErrorException();
        }
    }
}
