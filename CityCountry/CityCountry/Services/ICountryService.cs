using CityCountry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Services
{
    public interface ICountryService
    {
        void AddCountry(AddCountryFormModel country);

        void EditCountry(string id, ChangeCountryFormModel country);

        void DeleteCountry(string countryId);

        bool CountryAlreadyExist(string countryName);

        IEnumerable<CountryViewModel> AllCountries(int currentPage);

        CountryViewModel GetCountryById(string countryId);
    }
}
