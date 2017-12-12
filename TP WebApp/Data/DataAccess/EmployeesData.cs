using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class EmployeesData
    {
        public void Create(Employee employee)
        {
            using (var context = new Context())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public List<Employee> ReadAll()
        {
            using (var context = new Context())
            {
                return context.Employees
                    .AsNoTracking()
                    .ToList();
            }
        }

        public Employee Read(int id)
        {
            using (var context = new Context())
            {
                return context.Employees
                    .AsNoTracking()
                    .Where(c => c.ID == id)
                    .FirstOrDefault();
            }
        }

        public void Update(Employee employeeUpdated)
        {
            using (var context = new Context())
            {
                var employee = context.Employees
                    .Where(c => c.ID == employeeUpdated.ID)
                    .FirstOrDefault();

                var country = context.Countries
                    .Where(c => c.ID == employeeUpdated.Country.ID)
                    .FirstOrDefault();

                var currentShift = context.Shifts
                    .Where(c => c.ID == employeeUpdated.CurrentShift.ID)
                    .FirstOrDefault();

                employee.FirstName = employeeUpdated.FirstName;
                employee.LastName = employeeUpdated.LastName;
                employee.Country = country;
                employee.EntryDate = employeeUpdated.EntryDate;
                employee.CurrentShift = currentShift;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var employee = context.Employees
                    .Where(c => c.ID == id)
                    .FirstOrDefault();

                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }


    }
}
