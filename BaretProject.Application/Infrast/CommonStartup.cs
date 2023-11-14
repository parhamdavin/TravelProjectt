using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.Services.BusinessTypeServices;
using BaretProject.Application.Services.Citys;
using BaretProject.Application.Services.CityService;
using BaretProject.Application.Services.CustomerServices;
using BaretProject.Application.Services.Food;
using BaretProject.Application.Services.Food.Menu;
using BaretProject.Application.Services.FoodService;
using BaretProject.Application.Services.Kitchens.Kitchen_financial_Info;
using BaretProject.Application.Services.Kitchens.KitchenManagerReService;
using BaretProject.Application.Services.Kitchens.KitchenService;
using BaretProject.Application.Services.Orders;
using BaretProject.Application.Services.Permissions;
using BaretProject.Application.Services.ProvinceService;
using BaretProject.Application.Services.Rolese;
using BaretProject.Application.Services.UserServices;
using BaretProject.Application.Services.WalletService;
using BaretProject.Application.Services.WalletTypeService;
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
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFoodClipService, FoodClipService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IBusinessTypeService, BusinessTypeService>();
            services.AddScoped<IKitchen_financial_Info_Services, Kitchen_financial_Info_Services>();
            services.AddScoped<IKitchenManagerReService, KitckenManagerReService>();
            services.AddScoped<IKitchenService, KitchenServices>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletTypeService, WalletTypeService>();
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
