using Data.Entities;
using Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CrudEmployee
    {

        private Repository<Employee> repoEmployees = new Repository<Employee>();

        public void Create(EmployeeModel employee)
        {

            var auxCountry = new Country();

            if (employee.Country != null)
            {

                auxCountry.CountryID = employee.Country.CountryID;

                auxCountry.CountryName = employee.Country.CountryName;

            }

            var auxShift = new ConvertShift().Convert(employee.CurrentShift);

            var newEmployee = new Employee()
            {
                EmployeeID = employee.EmployeeID,

                FirstName = employee.FirstName,

                LastName = employee.LastName,

                Country = auxCountry,

                EntryDate = employee.EntryDate,

                CurrentShift = auxShift,

            };

            repoEmployees.Persist(newEmployee);

            repoEmployees.SaveChanges();

        }


        public EmployeeModel Read(int id)
        {
            var employee = repoEmployees.Set().FirstOrDefault(c => c.EmployeeID == id);

            if (employee != null)
            {

                var readEmployee = new EmployeeModel();

                readEmployee.EmployeeID = employee.EmployeeID;

                readEmployee.FirstName = employee.FirstName;

                readEmployee.LastName = employee.LastName;

                readEmployee.Country.CountryName = employee.Country.CountryName;

                readEmployee.EntryDate = employee.EntryDate;

                readEmployee.CurrentShift = new ConvertShift().ConvertModel(employee.Shift);

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

                auxCountry.CountryID = employee.Country.CountryID;

                auxCountry.CountryName = employee.Country.CountryName;

            }

            var auxShift = new ConvertShift().Convert(employee.CurrentShift);

            var employeeUpdate = repoEmployees.Set().FirstOrDefault(c => c.EmployeeID == employee.EmployeeID);

            if (employeeUpdate != null)
            {
                employeeUpdate.FirstName = employee.FirstName;

                employeeUpdate.LastName = employee.LastName;

                employeeUpdate.Country = auxCountry;

                employeeUpdate.EntryDate = employee.EntryDate;

                employeeUpdate.CurrentShift = auxShift;

                repoEmployees.SaveChanges();

                return 1;

            }

            return 0;




        }

        public int Delete(int id)
        {

            var employeeDelete = repoEmployees.Set().FirstOrDefault(c => c.EmployeeID == id);

            if (employeeDelete == null)
            {
                return 0;
            }

            //revisar cuando este la bd que elimine bien o ver si hay que eliminar otra cosa antes

            repoEmployees.Remove(employeeDelete);

            repoEmployees.SaveChanges();

            return 1;

        }

    }
}
