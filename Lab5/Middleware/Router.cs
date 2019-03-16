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

            await context.Response.WriteAsync(
                "<div><form action=\"/calc\" method=\"GET\">" +
                "<input type = \"text\" name = \"left\"/>" +
                "<select name = \"op\" value = \"+\" >" +
                "<option value=\"+\">+</option>" +
                "<option value=\"*\">*</option>" +
                "<option value=\"-\">-</option>" +
                "<option value=\"/\">/</option>" +
                "</select>" +
                "<input type = \"text\" name = \"right\"/>" +
                "<input type = \"submit\" />" +
                "</form ></div>"
            ); 

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
