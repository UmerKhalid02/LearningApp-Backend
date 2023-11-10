using LearningApp.Application.Exceptions;

namespace LearningApp.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = "")
        {
            this.Message = message;
            this.PayLoad = data;
        }

        public Response(bool success, T data, string message, List<ErrorModel> errors)
        {
            this.Success = success;
            this.Message = message;
            this.PayLoad = data;
            this.Errors = errors;
        }

        public Response(bool success, T data, string message)
        {
            this.Success = success;
            this.Message = message;
            this.PayLoad = data;
            this.Errors = null;
        }

        public List<ErrorModel> Errors { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T PayLoad { get; set; }
    }
}
