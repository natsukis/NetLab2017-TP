using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Crud;
using Services.Models;

namespace Presentacion.Controllers
{
    public class EmployeeController : Controller
    {
        private CrudEmployee crudEmployee;

        public EmployeeController()
        {
            this.crudEmployee = new CrudEmployee();
        }

        public ActionResult Form ()
        {
            crudEmployee.
        }

      
    }
}