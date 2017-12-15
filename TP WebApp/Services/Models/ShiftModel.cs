using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ShiftModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public short InitialHour { get; set; }

       
        public short EndingHour { get; set; }

        public virtual List<EmployeeModel> Employees { get; set; }

    }
}
