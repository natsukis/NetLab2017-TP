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
            if (ModelState.IsValid)
            {
                crudCountry.Create(countryModel);
                return View("Index", crudCountry.GetAll());
            }
            else return View("Index", crudCountry.GetAll());
        }

        public ActionResult Update(int countryID)
        {
            if (ModelState.IsValid)
            {
                var country = crudCountry.Read(countryID);
                return View(country);
            }
            else return View("Index", crudCountry.GetAll());
        }

        [HttpPost]
        public ActionResult Update(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                crudCountry.Update(countryModel);
                return View("Index", crudCountry.GetAll());
            }
            else return View("Index", crudCountry.GetAll());
        }

        public ActionResult Delete(int countryID)
        {
            if (ModelState.IsValid)
            {
                crudCountry.Delete(countryID);
                return View("Index", crudCountry.GetAll());
            }
            else return View("Index", crudCountry.GetAll());
        }

        
    }
}