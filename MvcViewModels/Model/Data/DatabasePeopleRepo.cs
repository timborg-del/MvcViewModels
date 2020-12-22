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
        public Person Create(string name, City city, string phoneNumber)
        {
            Person person = new Person(name, city, phoneNumber);

            _peopleDbContext.PeopleList.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public bool Delete(Person person)
        {
            
            _peopleDbContext.PeopleList.Remove(person);
            _peopleDbContext.SaveChanges();
            throw new NotImplementedException();


        }

        public List<Person> Read()
        {
           return _peopleDbContext.PeopleList.ToList();
            
        }
        public Person Read(int id)
        {
            return _peopleDbContext.PeopleList.SingleOrDefault(personList => personList.Id == id);
            
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
