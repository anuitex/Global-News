using Entities;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Constants;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private NewsAppContext _context;
        private DbSet<Subscription> _set;

        public SubscriptionRepository(NewsAppContext context)
        {
            _context = context;
            _set = _context.Set<Subscription>();
        }

        public async Task<bool> InsertSubscriptionAsync(Subscription subscription)
        {
            Subscription oldRecord = await _set.FirstOrDefaultAsync(x => x.Email == subscription.Email && x.Category == subscription.Category);
            if (oldRecord != null)
            {
                return false;
            }

            var result = await _set.AddAsync(subscription);

            if (result.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Subscription>> GetSubscriptionsByCategoryAsync(Categories category)
        {
            List<Subscription> result = await _set.Where(x => x.Category == category).ToListAsync();
            return result;
        }
    }
}
