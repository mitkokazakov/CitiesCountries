using CityCountry.Common;
using CityCountry.Data;
using CityCountry.Data.Models;
using CityCountry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Services
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext db;
        public CountryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCountry(AddCountryFormModel country)
        {
            var currentCountry = new Country 
            {
                Name = country.Name
            };

            this.db.Countries.Add(currentCountry);
            this.db.SaveChanges();
        }


        public void DeleteCountry(string countryId)
        {
            var currentCountry = this.db.Countries.FirstOrDefault(c => c.Id == countryId);

            if (currentCountry != null) 
            {
                foreach (var city in currentCountry.Cities)
                {
                    this.db.Cities.Remove(city);
                }

                this.db.Countries.Remove(currentCountry);

                this.db.SaveChanges();
            }
        }

        public void EditCountry(string id, ChangeCountryFormModel country)
        {
            var currentCountry = this.db.Countries.FirstOrDefault(c => c.Id == id);

            if (currentCountry != null)
            {
                currentCountry.Name = country.Name;

                this.db.SaveChanges();
            }
        }

        public bool CountryAlreadyExist(string countryName)
        {
            return this.db.Countries.Any(c => c.Name == countryName);
        }

        public IEnumerable<CountryViewModel> AllCountries(int currentPage)
        {
            int countriesPerPage = Constants.EntitiesPerPage;

            int size = (currentPage - 1) * countriesPerPage;

            var allCountries = this.db.Countries.ToList().Skip(size).Take(countriesPerPage).Select(c => new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            return allCountries;
        }

        public CountryViewModel GetCountryById(string countryId)
        {
            var countryDb = this.db.Countries.FirstOrDefault(c => c.Id == countryId);

            var country = new CountryViewModel
            {
                Id = countryDb.Id,
                Name = countryDb.Name
            };

            return country;
        }
    }
}
