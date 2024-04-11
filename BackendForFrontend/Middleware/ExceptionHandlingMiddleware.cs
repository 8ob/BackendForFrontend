using Microsoft.AspNetCore.Http;
using System.Net;
using BackendForFrontend.Exceptions;
using BackendForFrontend.Models;

namespace BackendForFrontend.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails
            {
                StatusCode = (int)statusCode,
                Message = "An error occurred while processing your request."
            };

            if (exception is ApiException apiException)
            {
                statusCode = apiException.StatusCode;
                errorDetails.Message = apiException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
