using Services;
using Services.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class CountryController : Controller
    {

        private CrudCountry crudCountry;

        public CountryController()
        {
            crudCountry = new CrudCountry();
        }

        public ActionResult Index()
        {
            return View(crudCountry.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryModel countryModel)
        {
            crudCountry.Create(countryModel);
            return View("Index");
        }

        public ActionResult Update()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Update()
        //{
        //    return View();
        //}

        public ActionResult Delete(String countryName)
        {
            crudCountry.Delete(countryName);
            return View("Index",crudCountry.GetAll());
        }

        
    }
}