using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Shift
    {
        [Key]
        [Required]
        [StringLength(5)]
        public string ShiftID { get; set; }

        [Required]
        public short InitialHour { get; set; }

        [Required]
        public short EndingHour { get; set; }
    }
}
