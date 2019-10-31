using Entities;
using Models;
using Newtonsoft.Json;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class CityService : ICityService
    {
        private ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<SearchCityResultModel> FindCityByNameAsync(string namefilter)
        {
            var result = new SearchCityResultModel();
            List<City> searchResult = await _cityRepository.FindCityByNameAsync(namefilter);
            foreach (City city in searchResult)
            {
                var cityModel = new SearchCityResultModelItem()
                {
                    Country = city.Country,
                    Name = city.Name
                };

                result.Data.Add(cityModel);
            }

            return result;
        }

        private async Task<bool> InsertOrUpdateCiliesListAsync()
        {
            List<City> cityList = new List<City>();
            using (var reader = new StreamReader("cities.json"))
            {
                string json = await reader.ReadToEndAsync();
                cityList = JsonConvert.DeserializeObject<List<City>>(json);
            }

            bool result = await _cityRepository.InsertOrUpdateCiliesListAsync(cityList);
            return result;
        }
    }
}
