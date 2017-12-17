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
        public ActionResult Index()
        {
            CrudEmployee crudEmployee = new CrudEmployee();
            List<EmployeeModel> allEmployees = crudEmployee.ReadAll();
            ViewBag.AllEmployees = allEmployees;
            return View();

        }

        public ActionResult Form()
        {
            CrudCountry crudCountry = new CrudCountry();
            List<CountryModel> allCountries = crudCountry.GetAll();
            ViewBag.AllCountries = allCountries;

            ShowShift showShift = new ShowShift();
            List<ShiftModel> allShifts = showShift.ShowAll();
            ViewBag.AllShifts = allShifts;
            
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeModel employee)
        {
            CrudEmployee crudEmployee = new CrudEmployee();
            crudEmployee.Create(employee);

            return RedirectToAction("Index");


        }


    }
}