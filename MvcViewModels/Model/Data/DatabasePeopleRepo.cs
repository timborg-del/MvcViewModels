using Microsoft.EntityFrameworkCore;
using MvcViewModels.Model.Data.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly RegistryDbContext _peopleDbContext;
        public DatabasePeopleRepo(RegistryDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(string name, City city, Country country, string phoneNumber)
        {
            Person person = new Person(name, city, country, phoneNumber);

            _peopleDbContext.PeopleList.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public bool Delete(Person person)
        {


            _peopleDbContext.PeopleList.Remove(person);
            int rowsEffected = _peopleDbContext.SaveChanges();

            if (rowsEffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            // throw new NotImplementedException();


        }


        public List<Person> Read()
        {
            //List<Person> peoplelist = _peopleDbContext.PeopleList.ToList();
            return _peopleDbContext.PeopleList.Include(p=>p.Languages).ThenInclude(pl=>pl.Language).ToList();


        }
        public Person Read(int id)
        {
            // This is EgerLoading Includep=>p.City converting ID of citys to obejects. 
            return _peopleDbContext.PeopleList.Include(p=>p.City).Include(l=>l.Languages).ThenInclude(l=>l.Language).SingleOrDefault(personList => personList.Id == id);
            //This is laceyLoading.
            //return _peopleDbContext.PeopleList.SingleOrDefault(personList => personList.Id == id);

        }

        public Person Update(Person person)
        {
            Person updatePerson = Read(person.Id);

            if (updatePerson == null)
            {
                return null;
            }
  
            updatePerson.Name = person.Name;
            updatePerson.City = person.City;
            updatePerson.PhoneNumber = person.PhoneNumber;
            updatePerson.Languages = person.Languages;
            updatePerson.Country = person.Country;
            _peopleDbContext.Update(updatePerson);
            _peopleDbContext.SaveChanges();

            return _peopleDbContext.PeopleList.Include(p => p.City).Include(l=>l.Languages).ThenInclude(l=>l.Language).SingleOrDefault(personList => personList.Id == person.Id);

        }
    }
}
