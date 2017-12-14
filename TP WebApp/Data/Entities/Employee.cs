using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public Country Country { get; set; }

        public DateTime EntryDate { get; set; }

        [Required]
        public Shift CurrentShift { get; set; }

        [Required]
        public decimal ValueByHour { get; set; }
        
    }
}
