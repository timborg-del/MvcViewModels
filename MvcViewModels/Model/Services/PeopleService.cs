using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model.Data;
using MvcViewModels.Model.Services;

namespace MvcViewModels.Model
{
    public class PeopleService : IPeopleService
    {
        //–Implements IPeopleService interface
        private readonly IPeopleRepo _peopleRepo;
        private readonly ILanguageService _languageService;
        public PeopleService(IPeopleRepo peopleRepo, ILanguageService languageService)
        {
            _languageService = languageService;
            _peopleRepo = peopleRepo;
        }
        public Person Add(CreatePersonViewModel createPersonViewModel)
        {

            return _peopleRepo.Create(createPersonViewModel.Name, createPersonViewModel.City, createPersonViewModel.Country, createPersonViewModel.PhoneNumber);

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
            if (person.ShouseLanguage != null)
            {

                Person persons = new Person();
                persons.Languages = new List<PersonLanguage>();

                foreach (var language in person.ShouseLanguage)
                {


                    Language lang = _languageService.FindBy(language);

                    PersonLanguage langID = new PersonLanguage() { LanguageID = lang.Id, Language = lang };
                    persons.Languages.Add(langID);


                }
                // PersonLanguage pl = new PersonLanguage();

                Person editPerson = new Person() { Id = id, Name = person.Name, City = person.City, Country = person.Country, PhoneNumber = person.PhoneNumber, Languages = persons.Languages };

                return _peopleRepo.Update(editPerson);
                throw new NotImplementedException();
            }
            else
            {
                Person editPerson = new Person() { Id = id, Name = person.Name, City = person.City, Country = person.Country, PhoneNumber = person.PhoneNumber};

                return _peopleRepo.Update(editPerson);
            }
           
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
