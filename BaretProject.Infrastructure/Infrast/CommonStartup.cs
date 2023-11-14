
using BaretProject.Application.Contracts;
using BaretProject.Application.Contracts.IRepositories;
using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.Services.Food.Menu;
using BaretProject.Domain.Infrast;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repositories;
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
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodClipRepository, FoodClipRepository>();
            services.AddScoped<IGroupFoodRepository, GroupFoodRepository>();
            services.AddScoped<IKitckenManagerReRepository, KitckenManagerReRepository>();
            services.AddScoped<IKitchenManagerRepository, KitchenManagerRepository>();
            services.AddScoped<IKitchen_financial_InfoRepository, Kitchen_financial_InfoRepository>();
            services.AddScoped<IKitchenRepository, KitckenRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IRoleRepository, RolesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletTypeRepository, WalletTypeRepository>();
            services.AddScoped<IBusiness_TypeRepository, BusinessTypeRepository>();
            services.AddDbContextPool<IApplicationContext, SqlServerContext>((options) =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=travel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }, poolSize: 16);
        }

        
    }
}
