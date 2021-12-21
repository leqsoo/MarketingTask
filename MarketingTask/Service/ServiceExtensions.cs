using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MarketingTask.Service
{
    public static class ServiceExtensions
    {
        public static void ConfigureExeptionHandler(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorHandling
                        {
                            Message = StringConstants.Error500,
                            StatusCode = context.Response.StatusCode
                        }.ToString());
                    }
                });
            });
        }
    }
}
