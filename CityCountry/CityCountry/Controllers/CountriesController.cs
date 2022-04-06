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
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCountryFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (this.countryService.CountryAlreadyExist(model.Name))
            {
                TempData["Error"] = "Country with that name already exists";

                return this.View();
            }

            this.countryService.AddCountry(model);

            return this.RedirectToAction("All","Countries");
        }

        public IActionResult All(AllCountriesVIewModel model)
        {
            var allCountries = this.countryService.AllCountries(model.CurrentPage);

            model.AllCountries = allCountries;

            return this.View(model);
        }

        [Authorize]
        public IActionResult Edit(string id) 
        {
            var country = this.countryService.GetCountryById(id);

            return this.View(country);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id,ChangeCountryFormModel model)
        {
            if (!this.ModelState.IsValid) 
            {
                return this.View();
            }

            this.countryService.EditCountry(id, model);

            return this.RedirectToAction("All","Countries");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.countryService.DeleteCountry(id);

            return this.RedirectToAction("All", "Countries");
        }
    }
}
