using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.DataAccess
{
    public class EmployeesData
    {
        private Repository<Employee> Repository;

        public EmployeesData()
        {
            this.Repository = new Repository<Employee>();
        }

        public void Create(Employee employee)
        {
            this.Repository.Persist(employee);
            this.Repository.SaveChanges();
        }

        public List<Employee> ReadAll()
        {
            return this.Repository.Set().ToList();
        }

        public Employee Read(int id)
        {
            using (var context = new Context())
            {
                return context.Employees
                    .Include(c => c.Country)
                    .Include(c => c.CurrentShift)
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
                    .First();

                //country proxy
                var country = context.Countries
                    .Where(c => c.ID == employeeUpdated.Country.ID)
                    .FirstOrDefault();
                
                //shift proxy
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
            var employee = Repository.GetById(id);
            Repository.Remove(employee);
            Repository.SaveChanges();
        }


    }
}
