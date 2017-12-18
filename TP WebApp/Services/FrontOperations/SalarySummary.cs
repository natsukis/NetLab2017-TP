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

        public HourSalaryModel Summary(DateTime time, EmployeeModel employee)
        {

            var listShift = repoControl.ReadEmployeeByDate(time, employee.ID);

            var employeeSumary = new HourSalaryModel();

            employeeSumary.Control = new List<ShiftControlModel>();

            foreach (var x in listShift)
            {

                employeeSumary.Salary += (x.WorkedHours * employee.ValueByHour);

                employeeSumary.Control.Add(new ShiftControlModel()
                {
                    ID = x.ID,
                    Day = x.Day,
                    Entry = (DateTime)x.Entry,
                    Exit = (DateTime)x.Exit,
                    WorkedHours = CalculateWork((DateTime)x.Entry, (DateTime)x.Exit)

                });

            }

            employeeSumary.Employee = employee;

            return employeeSumary;

        }

        public decimal CalculateWork(DateTime entry, DateTime exit)
        {

            return exit.Hour + exit.Minute - entry.Hour - entry.Minute;
        }


    }
}
