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

        public ShiftControl ReadByID(int id)
        {
            using (var context = new Context())
            {
                return context.ShiftControl
                    .Include(c => c.Employee)
                    .AsNoTracking()
                    .Where(c => c.ID == id)
                    .FirstOrDefault();
            }
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
            try
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
            catch (Exception)
            {
                throw new Exception("Failed to create new shift.");
            }
        }

        public void Update(ShiftControl shiftControlEdited)
        {
            try
            {
                var shiftControl = this.Repository.GetById(shiftControlEdited.ID);

                var entry = (DateTime)shiftControlEdited.Entry;
                var exit = (DateTime)shiftControlEdited.Exit;

                if (entry.Year == DateTime.Today.Year)
                shiftControl.Entry = shiftControlEdited.Entry;
                if (exit.Year == DateTime.Today.Year)
                    shiftControl.Exit = shiftControlEdited.Exit;
                shiftControl.WorkedHours = shiftControlEdited.WorkedHours;

                Repository.Update(shiftControl);
                Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to save changes.");
            }

        }

        public void Delete(int id)
        {
            try
            {
                var shiftControl = this.Repository.GetById(id);

                if (shiftControl == null)
                    throw new Exception("The shift doesn't exist.");

                Repository.Remove(shiftControl);
                Repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to remove the shift.");
            }
        }
    }
}
