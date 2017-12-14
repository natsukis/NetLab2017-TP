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

       

    }
}
