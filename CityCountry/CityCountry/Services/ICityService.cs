using CityCountry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Services
{
    public interface ICityService
    {
        bool CityAlreadyExists(string cityName);

        void AddCity(AddCityFormModel city);

        void EditCity(string id,ChangeCityFormModel city);

        void DeleteCity(string cityId);

        CityViewModel GetCityById(string id);

        IEnumerable<CityViewModel> AllCities(int currentPage);
    }
}
