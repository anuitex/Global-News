using EFCore.BulkExtensions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class CityRepository : ICityRepository
    {
        private NewsAppContext _context;
        private DbSet<City> _set;

        public CityRepository(NewsAppContext context)
        {
            _context = context;
            _set = _context.Set<City>();
        }

        public async Task<bool> InsertOrUpdateCiliesListAsync(List<City> cities)
        {
            try
            {
                await _set.AddRangeAsync(cities);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public async Task<List<City>> FindCityByNameAsync(string namefilter)
        {
            List<City> result = await _set.Where(x => x.Name.ToLower().Contains(namefilter.ToLower())).ToListAsync();
            return result;
        }
    }
}
