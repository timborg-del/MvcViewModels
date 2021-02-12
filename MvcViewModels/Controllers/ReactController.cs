using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model;
using MvcViewModels.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcViewModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ICitysService _cityService;
         
        // GET: api/<ReactController>
        public ReactController(IPeopleService peopleService, ICitysService citysService)
        {
            _cityService = citysService;
            _peopleService = peopleService;
        }
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            // Allow calls coming from outside the Host
           
           
            PeopleViewModel people = _peopleService.All();
            var onePerson = people.personList;
            //string personName = onePerson.Name;
            //onePerson[0].Country = null;
            return onePerson;
        }
        [HttpGet ("cities")]
        public IEnumerable<City> GetCity()
        {
            CityViewModel city = _cityService.All();
            var cityList = city.cityList;
            return cityList;
        }
        // GET api/<ReactController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person person = _peopleService.FindBy(id);
            person.Country = null;
            if (person.City != null)
            {
                person.City.Citiezens = null;
            }
            return person;
            //set null
        }
        // POST api/<ReactController>
        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreatePersonViewModel createPersonViewModel)
        {

            if (ModelState.IsValid)
            {
             
                createPersonViewModel.City = _cityService.FindBy(createPersonViewModel.City.Id);
                createPersonViewModel.Countries = null;
                createPersonViewModel.Country = null;

                Person person = _peopleService.Add(createPersonViewModel);
                if (person.City != null && person.Languages == null)
                {
                 person.City.Citiezens = null;
                 person.City.Countries = null;
                 person.Languages = null;

                }
                person.Country = null;
                return Created("URI to car omitted", person);
            }

            return BadRequest(createPersonViewModel);
        }
        // PUT api/<ReactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<ReactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          bool personDelete =  _peopleService.Remove(id);
        }
    }
}





