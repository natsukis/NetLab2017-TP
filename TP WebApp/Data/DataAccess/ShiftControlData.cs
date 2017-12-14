using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.DataAccess
{
    public class ShiftControlData
    {
        private Repository<ShiftControl> Repository;

        public ShiftControlData()
        {
            Repository = new Repository<ShiftControl>();
        }

        public ShiftControl Read(DateTime date, int employeeID)
        {
            using (var context = new Context())
            {
                return context.ShiftControl
                    .Include(c => c.Employee)
                    .AsNoTracking()
                    .Where(c => c.Day == date && c.Employee.ID == employeeID)
                    .FirstOrDefault();
            }
        }

        public List<ShiftControl> ReadEmployeeByDate(DateTime date, int id)
        {
            using (var context = new Context())
            {
                return context.ShiftControl
                    .Include(c => c.Employee)
                    .AsNoTracking()
                    .Where(c => c.Day.Month == date.Month &&
                        c.Day.Year == date.Year && c.Employee.ID == id)
                    .ToList();
            }
        }

        public List<ShiftControl> ReadAll()
        {
            using (var context = new Context())
            {
                return context.ShiftControl
                    .Include(c => c.Employee)
                    .AsNoTracking()
                    .ToList();
            }
        }

        public void Create(ShiftControl shiftControl)
        {
            using (var context = new Context())
            {
                var employee = context.Employees
                    .Where(c => c.ID == shiftControl.Employee.ID)
                    .FirstOrDefault();

                shiftControl.Employee = employee;

                context.ShiftControl.Add(shiftControl);
                context.SaveChanges();
            }
        }

        public void Update(ShiftControl shiftControlEdited)
        {
            var shiftControl = this.Repository.GetById(shiftControlEdited.ID);

            shiftControl.Entry = shiftControlEdited.Entry;
            shiftControl.Exit = shiftControlEdited.Exit;
            shiftControl.WorkedHours = shiftControlEdited.WorkedHours;

            Repository.Update(shiftControl);
            Repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var shiftControl = this.Repository.GetById(id);

            Repository.Remove(shiftControl);
            Repository.SaveChanges();
        }
    }
}
