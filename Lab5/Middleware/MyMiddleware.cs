using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Lab5.Middleware
{
    public class MyMiddleware
    {
        protected readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public virtual async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
        }
    }
}
