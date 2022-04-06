using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.DTO
{
    public class AddCityFormModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
