using BaretProject.Domain.Infrast;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Persistence.Infrat
{
    public class SecurityStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.High;

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           
        }
    }
}
