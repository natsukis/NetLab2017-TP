﻿using Data.Entities;
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
            try
            {
                //this.Repository.Persist(employee);
                //this.Repository.SaveChanges();
                using (var context = new Context())
                {
                    var country = context.Countries
                        .Where(c => c.CountryName == employee.Country.CountryName)
                        .First();

                    employee.Country = country;

                    var shift = context.Shifts
                        .Where(c => c.ID == employee.CurrentShift.ID)
                        .First();

                    employee.CurrentShift = shift;

                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Failed to create the new employee");
            }
        }

        public List<Employee> ReadAll()
        {
            //return this.Repository.Set().ToList();
            using (var context = new Context())
            {
                return context.Employees
                        .Include(c => c.Country)
                        .Include(c => c.CurrentShift)
                        .AsNoTracking()
                        .ToList();
            }
        }

        public Employee Read(int id)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Employees
                        .Include(c => c.Country)
                        .Include(c => c.CurrentShift)
                        .Where(c => c.ID == id)
                        .First();
                }
            }
            catch (Exception)
            {
                throw new Exception("The employee doesn't exist.");
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                this.Repository.Update(employee);
                this.Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to save changes.");
            }

        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {

                var employee = context.Employees
                    .Where(c => c.ID == id)
                    .FirstOrDefault();

                if (employee != null)
                {
                    Repository.Remove(employee);
                    Repository.SaveChanges();
                }
            }

        }
    }
}
