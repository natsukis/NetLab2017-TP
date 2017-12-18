using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class EmployeeModel
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

  
        public CountryModel Country { get; set; }

        public DateTime EntryDate { get; set; }


        public ShiftModel CurrentShift { get; set; }

        public decimal ValueByHour { get; set; }

    }
}
