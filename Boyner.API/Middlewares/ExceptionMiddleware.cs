using Boyner.API.Exceptions;
using Boyner.API.Exceptions.Messages;
using Boyner.API.Exceptions.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Boyner.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _ = e.Message;

            string message = "";

            if (e.GetType() == typeof(ValidationException) || e.GetType() == typeof(ApplicationException) || e.GetType() == typeof(WorkflowException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            else
            {
                message = ExceptionMessages.InternalServerError;
            }

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorViewModel(message, (int)httpContext.Response.StatusCode)));
        }
    }
}
