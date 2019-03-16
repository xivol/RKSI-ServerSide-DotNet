using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Lab5
{
    public class Startup
    {
        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        // For more information on how to configure your application, 
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculator, CalcService>();
        }

        public async Task AsyncWriter(HttpContext context)
        {
            ICalculator calc = context.RequestServices.GetService<ICalculator>();

            if (calc.Result != null)
                await context.Response.WriteAsync($"<pre>{calc}</pre>");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<Middleware.ErrorHandler>();
            app.UseMiddleware<Middleware.Router>();
            app.UseMiddleware<Middleware.CalcParser>();

            app.Run(AsyncWriter);
        }
    }
}
