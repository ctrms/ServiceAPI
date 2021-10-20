using Boyner.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Boyner.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void CustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
