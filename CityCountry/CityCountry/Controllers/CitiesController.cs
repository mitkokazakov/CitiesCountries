using CityCountry.DTO;
using CityCountry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCityFormModel model) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (this.cityService.CityAlreadyExists(model.Name))
            {
                TempData["Error"] = "City with that name already exists";

                return this.View();
            }

            if (!this.countryService.CountryAlreadyExist(model.CountryName))
            {
                TempData["Error"] = "Country with that name does not exist. Please first add country with that name!";

                return this.View();
            }

            this.cityService.AddCity(model);

            return this.RedirectToAction("All","Cities");
        }

        public IActionResult All(AllCitiesViewModel model)
        {

            var allCities = this.cityService.AllCities(model.CurrentPage);

            model.AllCities = allCities;

            return this.View(model);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var city = this.cityService.GetCityById(id);

            return this.View(city);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id, ChangeCityFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.cityService.EditCity(id, model);

            return this.RedirectToAction("All", "Cities");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.cityService.DeleteCity(id);

            return this.RedirectToAction("All","Cities");
        }
    }
}
