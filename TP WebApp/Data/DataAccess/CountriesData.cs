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
            try
            {
                this.Repository.Persist(country);
                this.Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to create the new country.");
            }
        }

        public Country Read(int id)
        {
            try
            {
                return this.Repository.Set()
                    .Where(c => c.ID == id)
                    .First();
            }
            catch (Exception)
            {
                throw new Exception("The country doesn't exist.");
            }
        }

        public List<Country> ReadAll()
        {
            return this.Repository.Set().ToList();
        }

        public void Update(Country country)
        {
            try
            {
                this.Repository.Update(country);
                this.Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to save changes.");
            }
        }

        public void Delete(Country country)
        {
            try
            {
                if (country == null)
                    throw new Exception("The country doesn't exist.");

                this.Repository.Remove(country);
                this.Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to remove the country.");
            }
        }
    }
}
