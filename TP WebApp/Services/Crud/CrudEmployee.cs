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
    public class CrudEmployee
    {

        private EmployeesData repoEmployees = new EmployeesData();

        public void Create(EmployeeModel employee)
        {

            var auxCountry = new Country();

            if (employee.Country != null)
            {

                auxCountry.ID = employee.Country.ID;

                auxCountry.CountryName = employee.Country.CountryName;

            }

            var auxShift = new ConvertShift().Convert(employee.CurrentShift);

            var newEmployee = new Employee()
            {
                
                FirstName = employee.FirstName,

                LastName = employee.LastName,

                Country = auxCountry,

                EntryDate = employee.EntryDate,

                CurrentShift = auxShift,

            };

            repoEmployees.Create(newEmployee);

        }


        public EmployeeModel Read(int id)
        {
            var employee = repoEmployees.Read(id);

            if (employee != null)
            {

                var readEmployee = new EmployeeModel();

                readEmployee.ID = employee.ID;

                readEmployee.FirstName = employee.FirstName;

                readEmployee.LastName = employee.LastName;

                readEmployee.Country.CountryName = employee.Country.CountryName;

                readEmployee.EntryDate = employee.EntryDate;

                readEmployee.CurrentShift = new ConvertShift().ConvertModel(employee.CurrentShift);

                return readEmployee;
            }
            else
            {
                return null;
            }
        }

        public int Update(int id, EmployeeModel employee)
        {

            var auxCountry = new Country();

            if (employee.Country != null)
            {
                auxCountry.ID = employee.Country.ID;

                auxCountry.CountryName = employee.Country.CountryName;

            }

            var auxShift = new ConvertShift().Convert(employee.CurrentShift);

            var verification = repoEmployees.Read(employee.ID);

            if (verification != null)
            {
                var employeeUpdate = new Employee
                {
                    FirstName = employee.FirstName,

                    LastName = employee.LastName,

                    Country = auxCountry,

                    EntryDate = employee.EntryDate,

                    CurrentShift = auxShift
                };
                

                repoEmployees.Update(employeeUpdate);

                return 1;

            }

            return 0;
            
        }

        public int Delete(int id)
        {

            var employeeDelete = repoEmployees.Read(id);

            if (employeeDelete == null)
            {
                return 0;
            }

            //revisar cuando este la bd que elimine bien o ver si hay que eliminar otra cosa antes

            repoEmployees.Delete(employeeDelete);

            
            return 1;

        }

    }
}