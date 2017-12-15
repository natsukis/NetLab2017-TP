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
        public ActionResult Index()
        {
            CrudEmployee crudEmployee = new CrudEmployee();
            List<EmployeeModel> allEmployees = crudEmployee.ReadAll();
            ViewBag.AllEmployees = allEmployees;
            return View();

        }


    }
}