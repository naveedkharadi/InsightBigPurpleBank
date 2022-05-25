using InsightBigPurpleBank.Api.Helpers;
using InsightBigPurpleBank.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace InsightBigPurpleBank.Api.Middleware
{
    public static class GlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new Error()
                        {
                            Code = Constants.ErrorCodes._500_InternalServerError,
                            Detail = contextFeature.Error.Message,
                            Title = "Internal Server Error",
                        }.ToString());
                    }
                });
            });
        }
    }
}
