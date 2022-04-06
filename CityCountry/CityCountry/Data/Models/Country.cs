using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityCountry.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cities = new HashSet<City>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
