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

        [Required(ErrorMessage ="This field is required!")] 
        [StringLength(50, ErrorMessage = "This field must contain less than fifty characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50, ErrorMessage = "This field must contain less than fifty characters!")]
        public string LastName { get; set; }
        
        public CountryModel Country { get; set; }

        public DateTime EntryDate { get; set; }

        public ShiftModel CurrentShift { get; set; }

        public decimal ValueByHour { get; set; }

    }
}
