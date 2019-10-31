using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SearchCityResultModel
    {
        public List<SearchCityResultModelItem> Data { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }

        public SearchCityResultModel()
        {
            Data = new List<SearchCityResultModelItem>();
        }
    }

    public class SearchCityResultModelItem
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
