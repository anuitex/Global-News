using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;
using System.Configuration;

namespace BackgroundServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<NewsAppContext>(options =>
                    {
                        options.UseLazyLoadingProxies();
                        options.UseMySql("server=127.0.0.1;port=3306;database=newsapp;UserId=root; Password=password;");
                    });


                    services.AddScoped<IEmailSubscriptionService, EmailSubscriptionService>();
                    services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

                    services.AddHostedService<BackgroundEmailNewsSender>();
                });
    }
}
