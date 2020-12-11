using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class PeopleService : IPeopleService
    {
        //–Implements IPeopleService interface
        IPeopleRepo _peopleRepo = new InMemoryPeopleRepo();
        public Person Add(CreatePersonViewModel createPersonViewModel)
        {

            return _peopleRepo.Create(createPersonViewModel.Name, createPersonViewModel.City, createPersonViewModel.PhoneNumber);

        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
             //InMemoryPeopleRepo _caresRepo = new InMemoryPeopleRepo();
            peopleViewModel.personList = _peopleRepo.Read();
            ///peopleViewModel.personList 

            return peopleViewModel;

        }

        public Person Edit(int id, CreatePersonViewModel person)
        {
            Person editPerson = new Person() {Id = id, Name = person.Name, City = person.City, PhoneNumber= person.PhoneNumber };
             return _peopleRepo.Update(editPerson);
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
             //PeopleViewModel
             //return _peopleRepo.Read();
            throw new NotImplementedException();
        }

        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
            
            //throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if (person == null)
            {
                return false;

            }
            else
            {
                return _peopleRepo.Delete(person);
            }

        }
    }
}
