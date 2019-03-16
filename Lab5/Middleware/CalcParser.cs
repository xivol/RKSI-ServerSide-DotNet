using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Middleware
{

    public class CalcParser : MyMiddleware
    {
        public CalcParser(RequestDelegate next) : base(next)
        { }

        public override async Task InvokeAsync(HttpContext context)
        {
            string lStr = context.Request.Query["left"];
            string rStr = context.Request.Query["right"];
            string oStr = context.Request.Query["op"];

            ICalculator calc = context.RequestServices.GetService<ICalculator>();

            if ( string.IsNullOrWhiteSpace(lStr) ||
                 string.IsNullOrWhiteSpace(rStr) ||
                 string.IsNullOrWhiteSpace(oStr) )
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                calc.Left = double.Parse(lStr);
                calc.Right = double.Parse(rStr);
                calc.Operation = (CalculatorOperation) Enum.ToObject(typeof(CalculatorOperation), char.Parse(oStr));
                calc.Compute();
            }

            await base.InvokeAsync(context);
        }
    }
}
