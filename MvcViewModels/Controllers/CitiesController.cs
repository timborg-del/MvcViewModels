using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model;
using MvcViewModels.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Controllers
{
    public class CitiesController : Controller
    {

        private readonly IPeopleService _peopleService;
        private readonly ICitysService _citysService;

        public CitiesController(IPeopleService peopleService, ICitysService citysService)
        {
            _peopleService = peopleService;
            _citysService = citysService;
        }



        // GET: PeopleController
        public ActionResult Index()
        {

            CityViewModel citysList = _citysService.All();
            return View(citysList.cityList);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            City city = _citysService.FindBy(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCityViewModel)
        {
            if (ModelState.IsValid)
            {
                _citysService.Add(createCityViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCityViewModel);
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _citysService.FindBy(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(city);
            }
        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
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
