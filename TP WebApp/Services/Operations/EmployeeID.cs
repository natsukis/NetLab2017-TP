using Data.DataAccess;
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
        private EmployeesData repoEmployees = new EmployeesData();

        public  int Employeeinformation(string name, string lastname)
        {
            var employee = repoEmployees.ReadAll().FirstOrDefault(c => c.FirstName == name && c.LastName == lastname);

            if(employee != null)
            {
                return employee.ID;
            }
            else
            {
                return 0;
            }
        }

    }
}
