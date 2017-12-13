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
        private Repository<Country> Repository;

        public CountriesData()
        {
            this.Repository = new Repository<Country>();
        }

        public void Create(Country country)
        {
            this.Repository.Persist(country);
            this.Repository.SaveChanges();
        }

        public Country Read(int id)
        {
            return this.Repository.GetById(id);
        }

        public List<Country> ReadAll(int id)
        {
            return this.Repository.Set().ToList();
        }

        public void Update(Country countryUpdated)
        {
            var country = this.Repository.GetById(countryUpdated.ID);

            country.CountryName = countryUpdated.CountryName;

            this.Repository.Update(country);
            this.Repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var country = this.Repository.GetById(id);

            this.Repository.Remove(country);
            this.Repository.SaveChanges();
        }
    }
}
