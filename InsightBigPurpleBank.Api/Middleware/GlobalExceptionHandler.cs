using InsightBigPurpleBank.Api.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace InsightBigPurpleBank.Api.Middleware
{
    public static class GlobalExceptionHandler
    {
        /// <summary>
        /// Middleware extension method to wrap unhandled exceptions in an <see cref="Error"/> object.
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    logger.LogError(contextFeature.Error, "Internal Server Error");
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new _500_InternalServerError(contextFeature.Error).ToString());
                    }
                });
            });
        }
    }
}
