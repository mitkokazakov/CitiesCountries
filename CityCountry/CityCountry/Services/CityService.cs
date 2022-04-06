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
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext db;
        public CityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCity(AddCityFormModel city)
        {
            var country = this.db.Countries.FirstOrDefault(c => c.Name == city.CountryName);

            var currentCity = new City
            {
                Name = city.Name,
                Country = country
                
            };

            this.db.Cities.Add(currentCity);

            this.db.SaveChanges();
        }

        public IEnumerable<CityViewModel> AllCities(int currentPage)
        {
            int citiesPerPage = Constants.EntitiesPerPage;

            int size = (currentPage - 1) * citiesPerPage;

            var allCities = this.db.Cities.ToList().Skip(size).Take(citiesPerPage).Select(c => new CityViewModel 
            {
                Id = c.Id,
                Name = c.Name
            });

            return allCities;
        }

        public bool CityAlreadyExists(string cityName)
        {
            return this.db.Cities.Any(c => c.Name == cityName);
        }

        public void DeleteCity(string cityId)
        {
            var currentCity = this.db.Cities.FirstOrDefault(c => c.Id == cityId);

            if (currentCity != null)
            {
                this.db.Cities.Remove(currentCity);

                this.db.SaveChanges();
            }
        }

        public void EditCity(string id, ChangeCityFormModel city)
        {
            var currentCity = this.db.Cities.FirstOrDefault(c => c.Id == id);

            if (currentCity != null)
            {
                currentCity.Name = city.Name;

                this.db.SaveChanges();
            }
        }

        public CityViewModel GetCityById(string id)
        {
            var cityDb = this.db.Cities.FirstOrDefault(c => c.Id == id);

            var city = new CityViewModel
            {
                Id = cityDb.Id,
                Name = cityDb.Name
            };

            return city;
        }
    }
}
