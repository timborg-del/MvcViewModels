using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model;
using MvcViewModels.Model.Services;
using MvcViewModels.Model.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MvcViewModels.Controllers
{
    [Authorize (Roles = "Member,Admin,SuperAdmin")]
    public class PeopleController : Controller
    {

        private readonly IPeopleService _peopleService;
        private readonly ICitysService _citysService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;


        public PeopleController(IPeopleService peopleService, ICitysService citysService, ICountryService countryService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _citysService = citysService;
            _countryService = countryService;
            _languageService = languageService;
        }

        // GET: PeopleController
        public ActionResult Index()
        {
            LanguageViewModel languageList = _languageService.All();

            PeopleViewModel personList = _peopleService.All();
            return View(personList.personList);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person != null)
            {
                return View(person);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.Cities = _citysService.All().cityList;
            createPersonViewModel.Countries = _countryService.All().countrieList;
            createPersonViewModel.AllStoredLanguage = _languageService.All().LanguagesList;
            // createCountryViewModel.Cities = _citysService.All().cityList;
            return View(createPersonViewModel);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            PersonLanguage personLanguage = new PersonLanguage();
            //Person person = new Person();
            if (ModelState.IsValid)
            {
                createPersonViewModel.Country = _countryService.FindBy(createPersonViewModel.Country.Id);
                createPersonViewModel.City = _citysService.FindBy(createPersonViewModel.City.Id);
                //createPersonViewModel.PersonLanguage = _languageService.FindBy(createPersonViewModel.PersonLanguage.; 
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
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Name = person.Name;
            createPerson.PhoneNumber = person.PhoneNumber;
            createPerson.City = person.City;
            createPerson.Country = person.Country;

            createPerson.Cities = _citysService.All().cityList;
            createPerson.AllStoredLanguage = _languageService.All().LanguagesList;
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreatePersonViewModel person, int id)
        {
            if (person.ShouseLanguage != null)


                foreach (var language in person.ShouseLanguage)
                {
                    Language personLanguage = _languageService.FindBy(language);
                }

            // Make it work Save to database Language

            City city = _citysService.FindBy(person.City.Id);

            person.City = city;

            Person editPerson = _peopleService.Edit(id, person);

            return RedirectToAction(nameof(Index));
        }

        //Set Onely Admin
        // GET: PeopleController/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
