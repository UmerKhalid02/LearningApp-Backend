using System.Globalization;
using System.Runtime.Serialization;


// error code - 500 HTTP status code that indicates an issue on the web server's side
namespace LearningApp.Application.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base()
        {
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }

        public InternalServerErrorException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        protected InternalServerErrorException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("One or more errors occurred.")
        {
        }
    }
}
