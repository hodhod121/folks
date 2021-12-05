using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(75)]
        public string PersonName { get; set; }
        [Required]
        [MaxLength(75)]
        public string PersonPhone { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public string CountryCode { get; set; }
        public virtual CountryModel Country { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("City")]
        [DisplayName("City")]
        public string CityCode { get; set; }
        public virtual CityModel City { get; set; }
    }
}
