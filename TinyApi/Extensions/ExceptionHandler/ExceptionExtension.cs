using Microsoft.AspNetCore.Builder;

namespace TinyApi.Extensions.ExceptionHandler
{
    public static class ExceptionExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
