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
        public List<Employee> GetEmployees(int id)
        {
            using (var context = new Context())
            {
                return context.Shifts
                    .Include(c => c.Employees)
                    .Where(c => c.ID == id)
                    .FirstOrDefault()
                    .Employees;
            }
        }
    }
}
