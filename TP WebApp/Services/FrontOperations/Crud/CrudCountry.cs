using Data.DataAccess;
using Data.Entities;
using Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Crud
{
    public class CrudCountry
    {

        private CountriesData repoCountry = new CountriesData();
        private EmployeesData repoEmployees = new EmployeesData();

        public void Create(CountryModel country)
        {

            var auxCountry = new Country();

            if (country.Employees != null)
            {
                foreach (var x in country.Employees)
                {

                    auxCountry.Employees.Add(new Employee()
                    {
                        ID = x.ID,

                        FirstName = x.FirstName,

                        LastName = x.LastName,

                        EntryDate = x.EntryDate,

                        CurrentShift = new ConvertShift().Convert(x.CurrentShift),

                        ValueByHour = x.ValueByHour

                    });

                }
            }
            var newCountry = new Country()
            {
                ID = country.ID,

                CountryName = country.CountryName,

                Employees = auxCountry.Employees,

            };

            repoCountry.Create(newCountry);

        }
        

        public CountryModel Read(int id)
        {
            var country = repoCountry.Read(id);

            if (country != null)
            {
                var readCountry = new CountryModel()
                {
                    ID = country.ID,

                    CountryName = country.CountryName,
                };
                //foreach (var employee in country.Employees)
                //{
                //    readCountry.Employees.Add(new EmployeeModel
                //    {
                //        ID = employee.ID,
                //        FirstName = employee.FirstName,
                //        LastName = employee.LastName,
                //        EntryDate = employee.EntryDate,
                //        CurrentShift = new ConvertShift().ConvertModel(employee.CurrentShift),
                //        ValueByHour = employee.ValueByHour
                //    });
                //}

                return readCountry;
            }
            else
            {
                return null;
            }
        }

        public List<CountryModel> GetAll()
        {
            return repoCountry.ReadAll().Select(x => new CountryModel
            {
                ID = x.ID,
                CountryName = x.CountryName
            }).ToList();
        }
        

        public int Update(CountryModel country)
        {
            
            var countryUpdate = repoCountry.Read(country.ID);

            if (countryUpdate != null)
            {
               
                countryUpdate.CountryName = country.CountryName;
                
                repoCountry.Update(countryUpdate);

                return 1;
            }
           
                return 0;
           
        }


        public int Delete(int id)
        {
            var countryDelete = repoCountry.Read(id);
            if (countryDelete == null)
            {
                return 0;
            }

            //var auxDelete = repoEmployees.ReadAll().Where(c => c.Country.ID == id);

            //if (auxDelete != null)
            //{
            //    foreach (var employee in auxDelete)
            //    {

            //        repoEmployees.Delete(employee.ID);

            //    }

            //}
            repoCountry.Delete(countryDelete);

            return 1;
        }
        
    }
}