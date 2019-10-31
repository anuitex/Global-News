using Entities;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> AddSubscription(SubcsriptionModel model)
        {
            var subscribtion = new Subscription()
            {
                Email = model.Email,
                Category = model.Category,
                SubscribeAll = model.SubscribeAll,
                Created = DateTime.UtcNow
            };

            bool result = await _subscriptionRepository.InsertSubscriptionAsync(subscribtion);

            return result;
        }
    }
}
