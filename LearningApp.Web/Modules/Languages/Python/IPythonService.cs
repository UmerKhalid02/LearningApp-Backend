using LearningApp.Application.DataTransferObjects.LanguagesDTO.Python;

namespace LearningApp.Web.Modules.Languages.Python
{
    public interface IPythonService
    {
        public Task<PythonResponseDTO> RunCode(PythonRequestDTO code);
    }
}
