using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model;


namespace MvcViewModels.Controllers
{
    public class CountriesController : Controller
    {

        private readonly ICountryService _countrysService;
        private readonly ICitysService _citysService;
        


        public CountriesController(ICitysService citysService, ICountryService countrysService)
        {
            _countrysService = countrysService;
            _citysService = citysService;
        }
        // GET: Countries
        public ActionResult Index()
        {
            CountryViewModel countryList = _countrysService.All();
            return View(countryList);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            Country Country = _countrysService.FindBy(id);

            if (Country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(Country);
       
          
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
