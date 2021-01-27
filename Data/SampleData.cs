using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MvcCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCodeFirst.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any teams.
                if (context.Provinces.Any())
                {
                    return;   // DB has already been seeded
                }

                var provices = GetProvinces().ToArray();
                context.Provinces.AddRange(provices);
                context.SaveChanges();

                var cities = GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        private static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
                new City()
                {
                    CityName = "Surrey",
                    Population = 100000,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                    Province = context.Provinces.Find("BC"),
                },
                new City()
                {
                    CityName = "Richmond",
                    Population = 200000,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                    Province = context.Provinces.Find("BC"),
                },
                new City()
                {
                    CityName = "Coquitlam",
                    Population = 300000,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                    Province = context.Provinces.Find("BC"),
                },
                new City()
                {
                    CityName = "Davenport",
                    Population = 100000,
                    ProvinceCode = context.Provinces.Find("CP").ProvinceCode,
                    Province = context.Provinces.Find("CP"),
                },
                new City()
                {
                    CityName = "Kennewick",
                    Population = 200000,
                    ProvinceCode = context.Provinces.Find("CP").ProvinceCode,
                    Province = context.Provinces.Find("CP"),
                },
                new City()
                {
                    CityName = "Pasco",
                    Population = 300000,
                    ProvinceCode = context.Provinces.Find("CP").ProvinceCode,
                    Province = context.Provinces.Find("CP"),
                },
                new City()
                {
                    CityName = "Amarillo",
                    Population = 100000,
                    ProvinceCode = context.Provinces.Find("RM").ProvinceCode,
                    Province = context.Provinces.Find("RM"),
                },
                new City()
                {
                    CityName = "Albuquerque",
                    Population = 200000,
                    ProvinceCode = context.Provinces.Find("RM").ProvinceCode,
                    Province = context.Provinces.Find("RM"),
                },
                new City()
                {
                    CityName = "Scottsdale",
                    Population = 300000,
                    ProvinceCode = context.Provinces.Find("RM").ProvinceCode,
                    Province = context.Provinces.Find("RM"),
                },
            };

            return cities;
        }

        private static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>() {
                new Province()
                {
                    ProvinceCode = "BC",
                    ProvinceName = "British Columbia",
                },
                new Province()
                {
                    ProvinceCode = "CP",
                    ProvinceName = "Columbia Plateau",
                },
                new Province()
                {
                    ProvinceCode = "RM",
                    ProvinceName = "Rocky Mountain",
                },
            };
            return provinces;
        }
    }

}
