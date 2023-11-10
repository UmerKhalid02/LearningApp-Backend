using System.Globalization;
using System.Runtime.Serialization;


// error code - 204 returned by the server to indicate that a HTTP request has been successfully completed, and there is no message body.
namespace LearningApp.Application.Exceptions
{
    [Serializable]
    public class NoContentException : Exception
    {
        public NoContentException() : base()
        {
        }

        public NoContentException(string message) : base(message)
        {
        }

        public NoContentException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        protected NoContentException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("One or more errors occurred.")
        {
        }
    }
}
