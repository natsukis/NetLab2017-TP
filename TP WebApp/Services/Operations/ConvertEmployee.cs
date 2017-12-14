﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Operations
{
    public class ConvertEmployee
    {
        public EmployeeModel ConvertModel(Employee employee)
        {

            var readEmployee = new EmployeeModel();

            if (employee != null)
            {
               
                readEmployee.ID = employee.ID;

                readEmployee.FirstName = employee.FirstName;

                readEmployee.LastName = employee.LastName;

                readEmployee.Country.CountryName = employee.Country.CountryName;

                readEmployee.EntryDate = employee.EntryDate;

                readEmployee.CurrentShift = new ConvertShift().ConvertModel(employee.CurrentShift);

                readEmployee.ValueByHour = employee.ValueByHour;
                
            }

            return readEmployee;

        }


    }
}
