using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CrudCountry
    {

        private Repository<Country> repoCountry = new Repository<Country>();
        private Repository<Employee> repoEmployees = new Repository<Employee>();

        public void Create(CountryModel country)
        {

            var auxCountry = new Country();

            if (country.Employees != null)
            {
                foreach (var x in country.Employees)
                {

                    auxCountry.Employees.Add(new Employee()
                    {
                        EmployeeID = x.EmployeeID,

                        FirstName = x.FirstName,

                        LastName = x.LastName,

                        EntryDate = x.EntryDate,

                    });

                }

            }
            var newCountry = new Country()
            {
                CountryID = country.CountryID,

                CountryName = country.CountryName,

                Employees = auxCountry.Employees,

            };

            repoCountry.Persist(newCountry);

            repoCountry.SaveChanges();

        }





        public CountryModel Read(string name)
        {
            var country = repoCountry.Set().FirstOrDefault(c => c.CountryName == name);
                                                
            if (country != null)
            {

                var readCountry = new CountryModel()
                {

                    CountryID = country.CountryID,

                    CountryName = country.CountryName,
                };

                foreach (var employee in country.Employees)
                {
                    readCountry.Employees.Add(new EmployeeModel
                    {
                        EmployeeID = employee.EmployeeID,

                        FirstName = employee.FirstName,

                        LastName = employee.LastName,

                        Country = employee.Country,

                        EntryDate = employee.EntryDate,

                        CurrentShift = employee.CurrentShift,
                    });
                }

                return readCountry;
            }
            else
            {
                return null;
            }

        }

        public int Update(string name, CountryModel country)
        {

            var auxCountry = new Country();

            if (country.Employees != null)
            {
                foreach (var x in country.Employees)
                {

                    auxCountry.Employees.Add(new Employee()
                    {
                        EmployeeID = x.EmployeeID,

                        FirstName = x.FirstName,

                        LastName = x.LastName,

                        EntryDate = x.EntryDate,

                    });

                }
            }

            var countryUpdate = repoCountry.Set().FirstOrDefault(c => c.CountryName == name);
        
            if(countryUpdate != null)
            {
                countryUpdate.CountryID = country.CountryID;

                countryUpdate.CountryName = country.CountryName;

                countryUpdate.Employees = auxCountry.Employees;

                repoCountry.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
            

        }

        public int Delete(string name)
        {

            var countryDelete = repoCountry.Set().FirstOrDefault(c => c.CountryName == name);

            if (countryDelete == null)
            {
                return 0;
            }

            var auxDelete = repoEmployees.Set().Where(c => c.Country.CountryName == name);

            if (auxDelete != null)
            {
                foreach (var employee in auxDelete)
                {

                    repoEmployees.Remove(employee);

                }
                repoEmployees.SaveChanges();
            }

            repoCountry.Remove(countryDelete);

            repoCountry.SaveChanges();

            return 1;

        }

    }
}
