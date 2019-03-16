using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab5.Middleware
{
    public class ErrorHandler : MyMiddleware
    {
        public ErrorHandler(RequestDelegate next) : base(next)
        {}

        public override async Task InvokeAsync(HttpContext context)
        {
            await base.InvokeAsync(context);
            if (context.Response.StatusCode == 400)
            {
                await context.Response.WriteAsync("<h1>Wrong Query</h1>");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("<h1>Page Not Found</h1>");
            }
        }
    }
}
