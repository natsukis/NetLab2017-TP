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

                auxCountry.CountryName = employee.Country.CountryName;

            }

            //var auxShift = new ConvertShift().Convert(employee.CurrentShift);          -------------- Si desean pasar shift relleno
            var auxShift = new ShowShift().Select(employee.CurrentShift.Name);          //--------------en caso que solo deseen enviar el nombre turno


            var newEmployee = new Employee()
            {

                FirstName = employee.FirstName,

                LastName = employee.LastName,

                Country = auxCountry,

                EntryDate = employee.EntryDate,

                CurrentShift = auxShift,

                ValueByHour = employee.ValueByHour

            };

            repoEmployees.Create(newEmployee);

        }

        public List<EmployeeModel> ReadAll()
        {
            var listemployee = repoEmployees.ReadAll();

            var listModel = new List<EmployeeModel>();

            foreach (var employee in listemployee)
            {
                listModel.Add(new ConvertEmployee().ConvertModel(employee));
            }

            return listModel;

        }

        public EmployeeModel Read(int id)
        {
            var employee = repoEmployees.Read(id);

            if (employee != null)
            {

                var readEmployee = new ConvertEmployee().ConvertModel(employee);


                return readEmployee;
            }
            else
            {
                return null;
            }
        }

        public int Update(EmployeeModel employee)
        {

            var auxCountry = new Country();

            if (employee.Country != null)
            {
                auxCountry.CountryName = employee.Country.CountryName;

            }

            var auxShift = new ConvertShift().Convert(employee.CurrentShift);

            var employeeUpdate = repoEmployees.Read(employee.ID);

            if (employeeUpdate != null)
            {

                employeeUpdate.FirstName = employee.FirstName;

                employeeUpdate.LastName = employee.LastName;

                employeeUpdate.Country = auxCountry;

                employeeUpdate.EntryDate = employee.EntryDate;

                employeeUpdate.CurrentShift = auxShift;

                employeeUpdate.ValueByHour = employee.ValueByHour;

                repoEmployees.Update(employeeUpdate);

                return 1;

            }

            return 0;

        }

        public int Delete(int id)
        {

            //var employeeDelete = repoEmployees.Read(id);

            //if (employeeDelete == null)
            //{
            //    return 0;
            //}

            repoEmployees.Delete(id);

            return 1;

        }

    }
}