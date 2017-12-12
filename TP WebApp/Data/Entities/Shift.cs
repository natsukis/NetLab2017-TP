using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        public short InitialHour { get; set; }

        [Required]
        public short EndingHour { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
