using Microsoft.AspNetCore.Antiforgery;
using System.Net;
using System.Text.Json;
using LearningApp.Application.Wrappers;
using LearningApp.Application.Exceptions;

namespace LearningApp.Web.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorResponse<string>() { success = false, message = error?.Message };

                switch (error)
                {
                    case BadRequestException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case UnprocessableEntityException:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case InternalServerErrorException:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    case AntiforgeryValidationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ConflictException e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        responseModel.errors = e.ErrorModels;
                        break;

                    case UnauthorizedAccessException:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case NoContentException:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        break;

                    case NotSupportedException:
                        response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                        break;

                    default:
                        if (error?.Message.ToLower().Contains("No authenticationScheme was specified".ToLower()) == true)
                        {
                            response.StatusCode = (int)HttpStatusCode.Forbidden;
                            responseModel.message = "You don't have privileges to perform this action!";
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }

                        break;
                }
                
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}