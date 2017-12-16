using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
   public class HourSalaryModel
    {
       
        public HourSalaryModel()
        {
            Control = new List<ShiftControlModel>();
        }

        public EmployeeModel Employee { get; set; }

        public decimal Salary { get; set; }

        public List<ShiftControlModel> Control { get; set; }

    }
}
