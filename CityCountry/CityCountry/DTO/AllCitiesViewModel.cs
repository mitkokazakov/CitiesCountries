using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.DTO
{
    public class AllCitiesViewModel
    {
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<CityViewModel> AllCities { get; set; }
    }
}
