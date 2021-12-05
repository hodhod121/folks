using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Models
{
    public class CityModel
    {
        [Key]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public virtual CountryModel Country { get; set; }

        public CityModel(string code, string name, string countryCode, CountryModel country)
        {
            Code = code;
            Name = name;
            CountryCode = countryCode;
            Country = country;
        }

        public CityModel()
        {
        }
    }
}
