using Domain.Response;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using HttpContext = Microsoft.AspNetCore.Http.HttpContext;

namespace Application.Exceptions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //context.Response.ContentType = "application/json";

            //object errors = null;

            //if (exception.GetType() == typeof(ValidationException))
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    errors = ((ValidationException)exception).Errors;

            //    var responseModel =  ResponseDto<NoContent>.Fail(exception.Message);
            //    var result = JsonSerializer.Serialize(responseModel);
            //    await context.Response.WriteAsync(result);   
            //}

            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = ResponseDto<NoContent>.Fail(exception.Message);
            object errors = null;

            switch (exception)
            {
                case ValidationException e:
                    errors = ((ValidationException)exception).Errors;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case BusinessException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);


        }
    }
}
