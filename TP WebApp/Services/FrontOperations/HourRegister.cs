using Data.DataAccess;
using Data.Entities;
using Services.Models;
using Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HourRegister
    {

        private ShiftControlData repoControl = new ShiftControlData();
        private EmployeesData repoEmployees = new EmployeesData();
        private ShiftsData repoShift = new ShiftsData();


        public List<ShiftControlModel> FirstEmployeesHours(int shift)
        {
            var electedShift = repoShift.Read(shift);

            var listEmployee = repoEmployees.ReadAll().Where(c => c.CurrentShift.ID == shift);

            var listModel = new List<ShiftControlModel>();

            var shiftcontrol = new ShiftControlModel();

            if (listEmployee != null)
            {
                foreach (var x in listEmployee)
                {

                    var shifttData = new ShiftControl
                    {
                        Employee = x,
                        Day = DateTime.Today

                    };

                    repoControl.Create(shifttData);

                    var auxEmployee = new EmployeeModel();

                    if (x != null)
                    {
                        auxEmployee = new ConvertEmployee().ConvertModel(x);
                    }

                    listModel.Add(new ShiftControlModel()
                    {
                        ID = repoControl.Read(DateTime.Today, x.ID).ID,
                        Employee = auxEmployee,
                        Day = DateTime.Today,

                    });
                }

            }

            return listModel;
        }


        public List<ShiftControlModel> ControltEmployeesHours(int shift)
        {
            var electedShift = repoShift.Read(shift);

            var listEmployee = repoEmployees.ReadAll().Where(c => c.CurrentShift.ID == shift);

            var listModel = new List<ShiftControlModel>();

            if (listEmployee != null)
            {

                foreach (var y in listEmployee)
                {


                    var auxEmployee = new EmployeeModel();

                    if (y != null)
                    {
                        auxEmployee = new ConvertEmployee().ConvertModel(y);
                    }

                    var shiftcontrol = new ShiftControlModel();

                    var aux = repoControl.Read(DateTime.Today, y.ID);

                    listModel.Add(new ShiftControlModel()
                    {
                        ID = aux.ID,
                        Employee = auxEmployee,
                        Day = DateTime.Today,
                        Entry = (DateTime)aux.Entry,
                        Exit = (DateTime)aux.Exit

                    });
                }

            }

            return listModel;
        }



        public bool EntryHourVerification(ShiftControlModel shift) => shift.Entry == null;

        public bool ExitHourVerification(ShiftControlModel shift) => shift.Exit == null;


        public int InsertInitialHour(ShiftControlModel shift, DateTime hour)
        {
            try
            {



                var shiftControl = new ShiftControl
                {
                    ID = shift.ID,
                    Entry = hour,
                    Exit = shift.Exit,
                    WorkedHours = CalculateWork(shift.Exit, hour)

                };

                repoControl.Update(shiftControl);

                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public int InsertExitHour(ShiftControlModel shift, DateTime hour)
        {
            try
            {
                var shiftControl = new ShiftControl
                {
                    ID = shift.ID,
                    Entry = shift.Entry,
                    Exit = hour,
                    WorkedHours = CalculateWork(hour, shift.Entry)

                };

                repoControl.Update(shiftControl);

                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public decimal CalculateWork(DateTime entry, DateTime exit)
        {

            return exit.Hour + exit.Minute - entry.Hour - entry.Minute;
        }


    }
}
