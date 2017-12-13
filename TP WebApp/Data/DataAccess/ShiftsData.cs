using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.DataAccess
{
    public class ShiftsData
    {
        private Repository<Shift> Repository;

        public ShiftsData()
        {
            this.Repository = new Repository<Shift>();
        }

        public List<Employee> GetEmployees(int id)
        {
            using (var context = new Context())
            {
                return context.Shifts
                    .Include(c => c.Employees)
                    .AsNoTracking()
                    .Where(c => c.ID == id)
                    .FirstOrDefault()
                    .Employees;
            }
        }
        
        public List<Shift> ReadAll()
        {
            return this.Repository.Set().ToList();
        }

        public Shift Read(int id)
        {
            return this.Repository.GetById(id);
        }
        
    }
}
