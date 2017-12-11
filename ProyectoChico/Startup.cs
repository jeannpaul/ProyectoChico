using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProyectoChico.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ProyectoChico
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
          
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JotaContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("JotaConnectionString"));
            });
            services.AddTransient<JotaSeeder>();
            services.AddMvc();
            services.AddScoped<IJotaRepository, JotaRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
           
           // app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "App", Action = "Index" });
            }
            );

            if (env.IsDevelopment())
            {
                using (var scope=app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<JotaSeeder>();
                    seeder.Agregar();
                }
            }
        }
    }
}
