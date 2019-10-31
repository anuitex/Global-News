using Entities;
using NewsAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task<bool> InsertSubscriptionAsync(Subscription subscription);
        Task<List<Subscription>> GetSubscriptionsByCategoryAsync(Categories category);
    }
}
