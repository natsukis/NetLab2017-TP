using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmployeeController : Controller
    {
        private CrudEmployee crudEmployee;

        public EmployeeController(CrudEmployee crudEmployee)
        {
            this.crudEmployee = crudEmployee;
        }
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Add(EmployeeModel employee)
        {
            if()
        }
    }
}