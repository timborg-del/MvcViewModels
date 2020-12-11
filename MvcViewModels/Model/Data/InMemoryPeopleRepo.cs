using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        // –Implements IPeopleRepo interfaceand these two fields.
        private static List<Person> personList = new List<Person>();//{ new Person(++idCounter, "Tim", "Ugglanäs", 04949), new Person(++idCounter, "CHarlie", "Ugglanäs", 04949) };
        private static int idCounter = 0; //Defult value of in is 0
       

        public Person Create(string name, string city, string phoneNumber)
        {
            Person person = new Person(++idCounter, name, city, phoneNumber);

            personList.Add(person);

            return person;


        }

        public bool Delete(Person person)
        {
            personList.Remove(person);

            return true;
            //throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return personList;

            throw new NotImplementedException();
        }
        public Person Read(int id)
        {


            // Search With ID 
            foreach (var item in personList)
            {
                if (id == item.Id)
                {
                    return item;
                }

            }
            return null;


        }

        public Person Update(Person person)
        {
            Person updatePerson = Read(person.Id);

            if (updatePerson == null)
            {
                return null;
            }

            updatePerson.Id = person.Id;
            updatePerson.Name = person.Name;
            updatePerson.City = person.City;
            updatePerson.PhoneNumber = person.PhoneNumber;

            return updatePerson;
            
        }
    }
}
