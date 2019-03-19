using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab5.Middleware
{
    public class Router : MyMiddleware
    {
        public Router(RequestDelegate next) : base(next)
        {}

        public override async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            if (path == "/calc")
            {
                await base.InvokeAsync(context);
            }
            else if (path != "/")
            {
                context.Response.StatusCode = 404;
            }

        }
    }
}
