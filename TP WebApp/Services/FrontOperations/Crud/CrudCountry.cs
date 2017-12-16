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
                foreach (var employee in country.Employees)
                {
                    readCountry.Employees.Add(new EmployeeModel
                    {
                        ID = employee.ID,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        EntryDate = employee.EntryDate,
                        CurrentShift = new ConvertShift().ConvertModel(employee.CurrentShift),
                        ValueByHour = employee.ValueByHour
                    });
                }

                return readCountry;
            }
            else
            {
                return null;
            }
        }
        //public int Update(string name, CountryModel country)
        //{

        //    var auxCountry = new Country();
        //    if (country.Employees != null)
        //    {
        //        foreach (var x in country.Employees)
        //        {

        //            auxCountry.Employees.Add(new Employee()
        //            {
        //                ID = x.ID,

        //                FirstName = x.FirstName,

        //                LastName = x.LastName,

        //                EntryDate = x.EntryDate,

        //                CurrentShift = new ConvertShift().Convert(x.CurrentShift),

        //                ValueByHour = x.ValueByHour

        //            });

        //        }
        //    }

        //    var countryUpdate = repoCountry.Read(name);

        //    if (countryUpdate != null)
        //    {

        //        countryUpdate.CountryName = country.CountryName;

        //        countryUpdate.Employees = auxCountry.Employees;

        //        repoCountry.Update(countryUpdate);

        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }




        //}
        public void Update(CountryModel countryModel)
        {
            var country = repoCountry.Read(countryModel.ID);

            if (country == null)
                throw new Exception("La noticia no existe");

            country.CountryName = countryModel.CountryName;
            country.ID = countryModel.ID;
            

            repoCountry.Update(country);
        }
        public int Delete(int id)
        {
            var countryDelete = repoCountry.Read(id);
            if (countryDelete == null)
            {
                return 0;
            }

            var auxDelete = repoEmployees.ReadAll().Where(c => c.Country.ID == id);

            if (auxDelete != null)
            {
                foreach (var employee in auxDelete)
                {

                    repoEmployees.Delete(employee);

                }

            }
            repoCountry.Delete(countryDelete);

            return 1;
        }

        public List<CountryModel> GetAll()
        {
            return repoCountry.ReadAll().Select(x => new CountryModel
            {
                ID = x.ID,
                CountryName = x.CountryName
            }).ToList();
        }

    }
}