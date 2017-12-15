using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ShiftControlModel
    {
        public int ID { get; set; }

        public DateTime Day { get; set; }

        public EmployeeModel Employee { get; set; }

        public DateTime Entry { get; set; }

        public DateTime Exit { get; set; }

        public decimal WorkedHours { get; set; }

        
    }
}
