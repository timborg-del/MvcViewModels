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
    public class PeopleController : Controller
    {

        private readonly IPeopleService _peopleService;
        private readonly ICitysService _citysService;
        private readonly ICountryService _countryService;

        public PeopleController(IPeopleService peopleService, ICitysService citysService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _citysService = citysService;
            _countryService = countryService;
        }



        // GET: PeopleController
        public ActionResult Index()
        {

            PeopleViewModel personList = _peopleService.All();
            return View(personList.personList);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            Person person = _peopleService.FindBy(id);
            City city = _citysService.FindBy(id);
            Country country = _countryService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.Cities = _citysService.All().cityList;
            createPersonViewModel.Countries = _countryService.All().countrieList;
            // createCountryViewModel.Cities = _citysService.All().cityList;
            return View(createPersonViewModel);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            //Person person = new Person();
            if (ModelState.IsValid)
            {
                createPersonViewModel.Country = _countryService.FindBy(createPersonViewModel.Country.Id);
                createPersonViewModel.City = _citysService.FindBy(createPersonViewModel.City.Id);
                if (createPersonViewModel.City != null && createPersonViewModel.Country != null)
                {
                    _peopleService.Add(createPersonViewModel);
                    return RedirectToAction(nameof(Index));

                }

            }

            return View(createPersonViewModel);

        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            //createPersonViewModel.Cities = _citysService.All().cityList;
            //createPersonViewModel.Countries = _countryService.All().countrieList;
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Name = person.Name;
            createPerson.PhoneNumber = person.PhoneNumber;
            createPerson.City = person.City;
            createPerson.Country = person.Country;

            //PeopleViewModel personList = _peopleService.All();
            //Model.IPeopleRepo irepo = new IPeopleRepo();
            Person editPerson = _peopleService.Edit(person.Id, createPerson);


            return RedirectToAction(nameof(Index));


            //return RedirectToAction(nameof(Index));

        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                ViewBag.msg = "Person Was Removed.";
            }
            else
            {
                ViewBag.msg = "Unable to remove car with id: " + id;
            }

            return RedirectToAction(nameof(Index));
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
