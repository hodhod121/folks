using folk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Data
{
    public class FolkContext:DbContext
    {
        public FolkContext(DbContextOptions<FolkContext> options) : base(options)
        {
        }
        public virtual DbSet<PersonModel> Peoples { get; set; }
        public virtual DbSet<CountryModel> Countries { get; set; }
        public virtual DbSet<CityModel> Cities { get; set; }
    }
}
