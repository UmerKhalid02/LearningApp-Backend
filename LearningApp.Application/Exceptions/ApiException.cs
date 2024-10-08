﻿using System.Globalization;

namespace LearningApp.Application.Exceptions
{
    public class ApiException : Exception
    {
        public List<ErrorModel> errorModels { get; set; }

        public ApiException() : base()
        {

        }

        public ApiException(string message) : base(message)
        {

        }
        public ApiException(string message, List<ErrorModel> errorModels) : base(message)
        {
            this.errorModels = errorModels;
        }

        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
