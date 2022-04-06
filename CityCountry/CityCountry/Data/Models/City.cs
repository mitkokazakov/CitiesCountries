using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Data.Models
{
    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
