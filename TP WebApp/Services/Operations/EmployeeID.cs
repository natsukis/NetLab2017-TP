using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Operations
{
   public class EmployeeID
    {
        private Repository<Employee> repoEmployees = new Repository<Employee>();

        public  int Employeeinformation(string name, string lastname)
        {
            var employee = repoEmployees.Set().FirstOrDefault(c => c.FirstName == name && c.LastName == lastname);

            if(employee != null)
            {
                return employee.EmployeeID;
            }
            else
            {
                return 0;
            }
        }

    }
}
