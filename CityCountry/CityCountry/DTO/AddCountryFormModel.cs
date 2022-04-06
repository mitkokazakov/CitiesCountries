using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.DTO
{
    public class AddCountryFormModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
