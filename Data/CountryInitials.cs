using folk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Data
{
    public class CountryInitials
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FolkContext>();
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(
                        new CountryModel { Name = "Canada", Code = "CAN" },
                        new CountryModel { Name = "Cameroon",  Code = "CMR" },
                        new CountryModel { Name = "Burundi", Code = "BDI" }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
