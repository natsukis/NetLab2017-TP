using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Crud;
using Services.Models;
using Services.Operations;

namespace Presentacion.Controllers
{
    public class EmployeeController : Controller
    {

        private CrudEmployee crudEmployee;

        private CrudCountry crudCountry;

        private ShowShift showShift;

        public EmployeeController()
        {
            crudEmployee = new CrudEmployee();
            crudCountry = new CrudCountry();
            showShift = new ShowShift();
        }

        public ActionResult Index()
        {
            var allEmployees = crudEmployee.ReadAll();
            return View(allEmployees);
        }

        public ActionResult Form()
        {
            ViewBag.AllCountries = crudCountry.GetAll();
            ViewBag.AllShifts = showShift.ShowAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                crudEmployee.Create(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", employee);
            }
        }

        public ActionResult ModifyEmployee(EmployeeModel employee)
        {
            ViewBag.AllEmployees = crudEmployee.ReadAll();
            return View(); 
                
        }
        
    }
}