using System.Globalization;
using System.Runtime.Serialization;


// error code - 403 HTTP status code that indicates that the server understood the request but refuses to authorize it
namespace LearningApp.Application.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        protected ForbiddenException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("One or more errors occurred.")
        {
        }

    }
}