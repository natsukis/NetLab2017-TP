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
            
            return View();
        }
    }
}