using Entities;
using NewsAPI.Constants;
using NewsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmailSubscriptionService
    {
        Task<List<Article>> GetLatestNewsInCategory(Categories category);
        Task<List<Subscription>> GetSubscroptionsByCategory(Categories category);
        Task SendNewsToSubscribers(List<Article> news, List<Subscription> subscriptions);
    }
}
