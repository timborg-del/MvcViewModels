using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model;

namespace MvcViewModels.Controllers
{
    public class HomeController : Controller
    {
        //onely peopleService. in feild
         PeopleService _peopleService = new PeopleService();

        //private static List<Person> personList = new List<Person>();
      
        public IActionResult People()
        {

            PeopleViewModel dataContainer = _peopleService.All();
             
            //personList = dataContainer.personList;

            return View(dataContainer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel create = new CreatePersonViewModel();

            return View(create);
        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {

                Person people = _peopleService.Add(personViewModel);
                // Here i need to give it int and stuff
                //personViewModel.Add(new Person() { Id = ++idCounter,  Name = personViewModel.Name, PhoneNumber = personViewModel.PhoneNumber, City = personViewModel.City });
                return RedirectToAction(nameof(People));
            }
            //else if (!ModelState.IsValid)
           // {
                
               return PartialView(personViewModel);
           // }
        }
        public IActionResult Delete(int id)
        {
            
            if (_peopleService.Remove(id))
            {
                ViewBag.msg = "Person Was Removed.";
            }

            else
            {
                ViewBag.msg = "Unable to remove person with id: " + id;
            }

            PeopleViewModel indexViewModel = new PeopleViewModel();
            indexViewModel = _peopleService.All();
            Person person = new Person();
            return Ok();
            //return PartialView("_PersonPartialView", person );

            
             //return RedirectToAction(nameof(People));
        }
        public IActionResult AjaxFindById(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return NotFound();//404
            }
            else
            {
                return PartialView("_PersonPartialView", person);
            }
        }
        [HttpGet]
        public IActionResult CreateForm()
        {

            return PartialView("_PersonCreateAjaxPartialView");
        }
        [HttpGet]
        public IActionResult CreateEditForm(int id)
        {
            Person person = _peopleService.FindBy(id);
            return PartialView("_PersonEditPartialView", person);
        }
        [HttpPost]
        public IActionResult AjaxCreateForm(CreatePersonViewModel PersonViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(PersonViewModel);

                return PartialView("_PersonPartialView", person);
            }

            Response.StatusCode = 400;
            return PartialView("_PersonCreateAjaxPartialView", PersonViewModel);
        }
        public IActionResult Edit(Person person)
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.Name = person.Name;
            createPerson.PhoneNumber = person.PhoneNumber;
            createPerson.City = person.City;

            //Model.IPeopleRepo irepo = new IPeopleRepo();
            Person editPerson = _peopleService.Edit(person.Id, createPerson);

            return PartialView("_PersonPartialView", editPerson);

            
  
        }
    }
}





