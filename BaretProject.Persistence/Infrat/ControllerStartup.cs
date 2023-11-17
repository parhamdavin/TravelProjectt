using BaretProject.Domain.Infrast;
using GreenPipes.Filters;
using Hangfire.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Persistence.Infrat
{
    public class ControllerStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            IMvcBuilder config = services.AddControllers();
            config.ConfigureApiBehaviorOptions((options) =>
            {

                options.ClientErrorMapping[500].Title = "درخواست نامعتبر";
                options.ClientErrorMapping[403].Title = "منبع مورد نظر یافت نشد";
                options.InvalidModelStateResponseFactory = (Context) =>
                {
                    var values = Context.ModelState.Values.Where(state => state.Errors.Count != 0)
                        .Select(state => state.Errors.Select(p => new { errorMessage = p.ErrorMessage }));

                    return new BadRequestObjectResult(values);

                };
            });

            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "http://localhost:6000";
            //        options.RequireHttpsMetadata = false;

            //        options.Audience = "BaretProject.api";
            //    });



            ////Global
            //services.AddMvc().AddMvcOptions(c => c.Filters.AddService(typeof(LogFilter)));
            services.AddSwaggerGen(
           c =>
           {
               c.SwaggerDoc("v1.0", new OpenApiInfo
               {
                   Version = "ورژن یک",
                   Title = " وب سرویس آزانس مسافرتی ",
                   Description = " در این وب سرویس مشخصات آزانس مسافرتی شرح داده می شود",
                   TermsOfService = new Uri("https://example.com/terms"),
                   Contact = new OpenApiContact
                   {
                       Name = "Davin Team",
                       Email = string.Empty,
                       Url = new Uri("https://twitter.com/"),
                   },
                   License = new OpenApiLicense
                   {
                       Name = "Use under LICX",
                       Url = new Uri("https://example.com/license"),
                   }
               }
           );
           });
            services.AddMvc().AddMvcOptions(c => c.Filters.AddService(typeof(LogFilter)));

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
            IWebHostEnvironment env = app.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>

                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Baret API V1")
                    );

                //app.UseSwaggerUI();

            }


        }

       
    }
}
