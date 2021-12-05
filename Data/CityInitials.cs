using folk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Data
{
    public class CityInitials
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FolkContext>();
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(
                        new CityModel { Name = "Vancouver",  Code = "378",CountryCode="CAN" },
                        new CityModel { Name = "Abong‑Mbang",  Code = "379",CountryCode="CMR" },
                        new CityModel { Name = "Bubanza", Code = "380",CountryCode="BDI" }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
