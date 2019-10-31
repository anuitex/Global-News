using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using NewsAPI.Constants;
using System.Collections.Generic;
using System.Linq;
using NewsAPI.Models;
using Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundServices
{
    public class BackgroundEmailNewsSender : BackgroundService //Background tast to send emails with news
    {
        private readonly ILogger<BackgroundEmailNewsSender> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory; //DI container

        public BackgroundEmailNewsSender(ILogger<BackgroundEmailNewsSender> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                SendNewsletter(); // should not been awaited

                await Task.Delay((int)TimeSpan.FromMinutes(1).TotalMilliseconds, stoppingToken);
            }
        }

        private async Task SendNewsletter()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var emailSubscriptionService = scope.ServiceProvider.GetService<IEmailSubscriptionService>();//get from DI container
                List<Categories> categories = Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();

                foreach (var category in categories)
                {
                    List<Article> news = await emailSubscriptionService.GetLatestNewsInCategory(category);
                    List<Subscription> subscriptions = await emailSubscriptionService.GetSubscroptionsByCategory(category);

                    await emailSubscriptionService.SendNewsToSubscribers(news, subscriptions);
                }
            }
        }
    }
}
