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
        private HourRegister ShiftService;

        public ShiftController()
        {
            this.ShiftService = new HourRegister();
        }

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
        public ActionResult Cash(int month, int year, int employeeID)
        {
            return View();
        }
    }
}