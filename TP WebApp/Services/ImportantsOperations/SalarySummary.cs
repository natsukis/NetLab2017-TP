using Data.DataAccess;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

   public class SalarySummary
    {
        private ShiftControlData repoControl = new ShiftControlData();

        public HourSalaryModel Summary(DateTime time, EmployeeModel employee )
        {

            var listShift = repoControl.ReadEmployeeByDate(time, employee.ID);

            var employeeSumary = new HourSalaryModel();
            
            foreach (var x in listShift)
            {

                employeeSumary.Salary += (x.WorkedHours * employee.ValueByHour);
                employeeSumary.WorkHours += x.WorkedHours;

            }

            return employeeSumary;

        }

    }
}
