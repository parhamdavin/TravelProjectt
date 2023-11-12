using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaretProject.Domain.Infrast;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace shop.Core.Infrastructure
{
    public class TaskStartup:IApplicationStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {

                options.AllowSynchronousIO = true;
            });

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=.;Initial Catalog=hangfire;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True", new SqlServerStorageOptions
                {

                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true,

                }));

            services.AddHangfireServer();
            

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMilliseconds(1000)
            };

            app.UseHangfireServer(options);

        }

        public MiddleWarePriority Priority => MiddleWarePriority.High;
    }
}
