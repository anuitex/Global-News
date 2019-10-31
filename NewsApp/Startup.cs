using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Repositories;
using Services;
using Repositories.Interfaces;
using Entities;

namespace NewsApp
{
    public class Startup //TODO: Add logging
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NewsAppContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySql(Configuration.GetConnectionString("MySqlDB"));
            });

            services.Scan(scan => scan
                .FromAssemblyOf<SubscriptionService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service") ||
                                                             type.Name.EndsWith("Provider") ||
                                                             type.Name.EndsWith("Helper")))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblyOf<SubscriptionRepository>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseMvc();
            //app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "";

            //    if (env.IsDevelopment())
            //    {
            //        spa.use(npmScript: "start");
            //    }
            //});
        }
    }
}
