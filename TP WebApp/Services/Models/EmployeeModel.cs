using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class EmployeeModel
    {
        public int ID { get; set; }

  
        public string FirstName { get; set; }


        public string LastName { get; set; }

  
        public CountryModel Country { get; set; }

        public DateTime EntryDate { get; set; }


        public ShiftModel CurrentShift { get; set; }

    }
}
