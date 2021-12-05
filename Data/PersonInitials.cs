using folk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Data
{
    public class PersonInitials
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FolkContext>();
                if (!context.Peoples.Any())
                {
                    context.Peoples.AddRange(
                        new PersonModel { PersonName = "Mozafar", PersonPhone = "0345432",CountryCode="CAN",CityCode="378" },
                        new PersonModel { PersonName = "Samandar", PersonPhone = "076584358",CountryCode="CMR",CityCode="379" },
                        new PersonModel { PersonName = "Mamy", PersonPhone = "086875423",CountryCode="BDI",CityCode="380"}
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
