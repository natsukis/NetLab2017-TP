using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class CountryModel
    {
        public int ID { get; set; }
             
        public string CountryName { get; set; }

        public virtual List<EmployeeModel> Employees { get; set; }
    }

}

