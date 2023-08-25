using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.Services.City;
using BaretProject.Application.Services.CityService;
using BaretProject.Application.Services.Food;
using BaretProject.Application.Services.Food.Menu;
using BaretProject.Domain.Infrast;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Infart
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
          //  services.AddScoped<LogFilter>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFoodClipService, FoodClipService>();
            services.AddScoped<IMenuService, MenuService>();
           

        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
