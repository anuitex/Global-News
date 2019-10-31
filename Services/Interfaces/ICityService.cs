using Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICityService
    {
        Task<SearchCityResultModel> FindCityByNameAsync(string namefilter);
    }
}
