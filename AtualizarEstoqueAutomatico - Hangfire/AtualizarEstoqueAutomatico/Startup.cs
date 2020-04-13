using AtualizarEstoqueAutomatico.Jobs;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AtualizarEstoqueAutomatico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
            {
                var options = new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.FromMinutes(5)
                };

                config.UseSqlServerStorage("Data Source=andromeda2;Initial Catalog=CosmosPDP; User ID=SYSCOSMOS; Password=COSMOS", options);
            });

            services.AddScoped<IAtualizarEstoqueJob, AtualizarEstoqueJob>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHangfireDashboard("/Agendados");

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            });

            JobsSchedule.Schedule();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
