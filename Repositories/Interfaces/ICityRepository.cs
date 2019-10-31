using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<List<City>> FindCityByNameAsync(string namefilter);
        Task<bool> InsertOrUpdateCiliesListAsync(List<City> cities);
    }
}
