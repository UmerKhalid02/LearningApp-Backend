using System.Globalization;

// error code - 422 the server can't process your request, although it understands it. 
namespace LearningApp.Application.Exceptions
{
    public class UnprocessableEntityException : Exception
    {
        public List<ErrorModel> ErrorModels { get; set; }

        public UnprocessableEntityException() : base()
        {
        }

        public UnprocessableEntityException(string message) : base(message)
        {

        }
        public UnprocessableEntityException(string message, List<ErrorModel> errorModels) : base(message)
        {
            this.ErrorModels = errorModels;
        }

        public UnprocessableEntityException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
