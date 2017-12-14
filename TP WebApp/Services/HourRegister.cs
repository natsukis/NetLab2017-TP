using Data.DataAccess;
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

        //Este seria solo si pasara el dia, pero probablemente usemos el otro
        public List<EmployeeModel> EmployeesPerTurn(ShiftModel shift)
        {
            var electedShift = new ConvertShift().Convert(shift);

            var listEmployee = repoEmployees.ReadAll().Where(c=>c.CurrentShift == electedShift);

            var listModel = new List<EmployeeModel>();

            if (listEmployee != null)
            {
                foreach (var x in listEmployee)
                {
                    listModel.Add(new ConvertEmployee().ConvertModel(x));
                }
            }
           

            return listModel;
        }

        //Este recibe el dia y pasa como la hoja de horarios, probablemente sea el gran elegido
        public List<ShiftControlModel> EmployeesHours(ShiftModel shift)
        {
            var electedShift = new ConvertShift().Convert(shift);

            var listEmployee = repoEmployees.ReadAll().Where(c => c.CurrentShift == electedShift);

            var listModel = new List<ShiftControlModel>();

            if (listEmployee != null)
            {
                foreach (var x in listEmployee)
                {
                    var shiftcontrol = new ShiftControlModel();

                    listModel.Add(new ShiftControlModel()
                    {
                        Employee = new ConvertEmployee().ConvertModel(x),
                        Day = DateTime.Today

                    });
                }
            }


            return listModel;
        }

        
        public int InsertHour(ShiftControlModel shift, DateTime hour)
        {



            return 1;
        }



    }
}
