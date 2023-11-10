
// error code - 400 HTTP status code that indicates that the request sent by the client was syntactically incorrect.
namespace LearningApp.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {
        }

        public BadRequestException(string message) : base(message)
        {

        }
    }
}
