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
        private readonly IPeopleService _peopleService;

        public CountriesController(ICitysService citysService, ICountryService countrysService, IPeopleService peopleService)
        {
            _countrysService = countrysService;
            _citysService = citysService;
            _peopleService = peopleService;
        }
        // GET: Countries
        public ActionResult Index()
        {
            CountryViewModel countryList = _countrysService.All();
            return View(countryList.countrieList);
        }
        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            Country Country = _countrysService.FindBy(id);

            if (Country != null)
            {
                return View(Country);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Countries/Create
        public ActionResult Create()
        {

            CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();
            createCountryViewModel.Cities = _citysService.All().cityList;


            return View(createCountryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountryViewModel)
        {
            if (ModelState.IsValid)
            {

                _countrysService.Add(createCountryViewModel);
                return RedirectToAction(nameof(Index));

            }
            return View(createCountryViewModel);

        }

        public ActionResult Edit(int id)
        {
            Country country = _countrysService.FindBy(id);

            if (country != null)
            {
                return View(country);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            CreateCountryViewModel createCountrie = new CreateCountryViewModel();
            createCountrie.Name = country.Name;
            createCountrie.Cities = country.Cities;

            Country editCountrie = _countrysService.Edit(country.Id, createCountrie);

            return RedirectToAction(nameof(Index));

        }
        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            if (_countrysService.Remove(id))
            {
                ViewBag.msg = "Person Was Removed.";
            }
            else
            {
                ViewBag.msg = "Unable to remove car with id: " + id;
            }

            return RedirectToAction(nameof(Index));
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
