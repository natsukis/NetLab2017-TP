using Services;
using Services.Crud;
using Services.Models;
using Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ShiftController : Controller
    {
        private HourRegister hourRegister;
        private ShowShift showShift;

        public ShiftController()
        {
            hourRegister = new HourRegister();
            showShift = new ShowShift();
        }
    

        // Read shifts
        public ActionResult Index()
        {
            return View();
        }

        //Menu de registro de horarios
        public ActionResult Register()
        {
            return View(showShift.ShowAll());
        }

        [HttpPost]
        public ActionResult Register(int registerID)
        {
            return View("EmployeeTurn",hourRegister.EmployeesHours(registerID));
        }

        public ActionResult ShiftControl(ShiftControlModel shiftControlModel)
        {
            return View("ShiftControl", shiftControlModel);
        }

        [HttpPost]
        public ActionResult ShiftControlInsert(ShiftControlModel shiftControlModel)
        {
            if (!hourRegister.EntryHourVerification(shiftControlModel))
            {
                hourRegister.InsertInitialHour(shiftControlModel, shiftControlModel.Entry);
            }
            if (hourRegister.EntryHourVerification(shiftControlModel))
            {
                hourRegister.InsertExitHour(shiftControlModel, shiftControlModel.Exit);
            }

            return View("EmployeeTurn",showShift.ShowAll());
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


            var summary = SalaryService.Summary(date, employee);

            return View(summary);
        }
    }
}