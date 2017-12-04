using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IGreeter greeter, 
            ILogger<Startup> logger //specific configuration for Startup class
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //using delegate in a middleware
            //app.Use(next =>  //delegate
            //{
            //    return async context => //delegate
            //    {
            //        logger.LogInformation("Request Incoming"); //write on logger
            //        if (context.Request.Path.StartsWithSegments("/mym")) //path to hit
            //        {
            //            await context.Response.WriteAsync("hit!!"); //reach this 
            //            logger.LogInformation("Request Handled"); 
            //        }
            //        else
            //        {
            //            await next(context); //means pass to the next piece of middleware --> UseWelcomePage or the next that apply
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };

            //});

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //});

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessage();
                await context.Response.WriteAsync($"{greeting}--------{env.EnvironmentName}");//$ using interpolation feature of C# 6.0 better than String.format().....
            });
        }
    }
}
