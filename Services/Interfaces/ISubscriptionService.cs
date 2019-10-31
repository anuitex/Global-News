using Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<bool> AddSubscription(SubcsriptionModel model);
    }
}
