using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
           _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IMessageWriter svc)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //svc.Write(ex.Message);
                await httpContext.Response.WriteAsync($"{ex.Message}\n");
            }
        }
    }
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
