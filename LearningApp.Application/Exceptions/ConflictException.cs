using System.Globalization;

// error code - 409 HTTP status code that indicates that the request could not be processed because of conflict in the current state of the resource
namespace LearningApp.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public List<ErrorModel> ErrorModels { get; set; }

        public ConflictException() : base()
        {
        }

        public ConflictException(string message) : base(message)
        {

        }
        public ConflictException(string message, List<ErrorModel> errorModels) : base(message)
        {
            this.ErrorModels = errorModels;
        }

        public ConflictException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
