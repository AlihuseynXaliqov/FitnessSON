using System.Net.Mime;
using System.Text.Json;
using FitnessApp.Service.Helper.Exception.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace FitnessApp.API;

public static class GlobalException
{
    public static void UseGlobalException(this WebApplication app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                if (feature?.Error is BaseException ex)
                {
                    context.Response.StatusCode = ex.StatusCode;

                    var response = new
                    {
                        Message = ex.ErrorMessage, ex.StatusCode
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    var response = new
                    {
                        success = false,
                        Message = "An unexpected error occurred",
                        StatusCode = StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            });
        });
    }
}