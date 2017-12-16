using Services;
using Services.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ShiftController : Controller
    {

        // Read shifts
        public ActionResult Index()
        {
            return View();
        }

        //Menu de registro de horarios
        public ActionResult Register()
        {
            return View();
        }

        //Menu de cobrar
        public ActionResult Cash()
        {
            CrudEmployee service = new CrudEmployee();
            var employeeList = service.ReadAll();
            return View(employeeList);
        }

        [HttpPost]
        public ActionResult CashResult(int month, int year, int employeeID)
        {
            CrudEmployee service = new CrudEmployee();
            var employee = service.Read(employeeID);

            SalarySummary SalaryService = new SalarySummary();
            var date = new DateTime(year,month,1);


            var test = SalaryService.Summary(date, employee);

            return View();
        }
    }
}