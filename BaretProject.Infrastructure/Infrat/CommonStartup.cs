
using BaretProject.Application.Contracts;
using BaretProject.Domain.Infrast;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Infrastructure.Infrat
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void Configure(IApplicationBuilder app)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddDbContextPool<IApplicationContext, SqlServerContext>((options) =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=travel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }, poolSize: 16);
        }

        
    }
}
