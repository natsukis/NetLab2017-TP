using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ShiftControl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public DateTime? Entry { get; set; }

        public DateTime? Exit { get; set; }

        public int WorkedHours { get; set; }
    }
}
