using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class CountriesData
    {
        public void Create(Country country)
        {
            using (var context = new Context())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        public Country Read(int id)
        {
            using (var context = new Context())
            {
                return context.Countries
                    .AsNoTracking()
                    .Where(c => c.ID == id)
                    .FirstOrDefault();
            }
        }

        public List<Country> ReadAll(int id)
        {
            using (var context = new Context())
            {
                return context.Countries
                    .AsNoTracking()
                    .ToList();
            }
        }

        public void Update(Country countryUpdated)
        {
            using (var context = new Context())
            {
                var country = context.Countries
                    .Where(c => c.ID == countryUpdated.ID)
                    .FirstOrDefault();

                country.CountryName = countryUpdated.CountryName;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var country = context.Countries
                    .Where(c => c.ID == id)
                    .FirstOrDefault();

                context.Countries.Remove(country);
                context.SaveChanges();
            }
        }
    }
}
