using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model.Data;
using MvcViewModels.Model;

namespace MvcViewModels.Model.Services
{
    public class LanguageService : ILanguageService
    {

        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Add(CreateLanguageViewModel createLanguageViewModel)
        {
            return _languageRepo.Create(createLanguageViewModel.Name);
            throw new NotImplementedException();
        }

        public LanguageViewModel All()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel();
            languageViewModel.LanguagesList = _languageRepo.Read();

            return languageViewModel;
            //throw new NotImplementedException();
        }

        public Language Edit(int id, CreateLanguageViewModel language)
        {
            Language editLanguage = new Language() { Id = id, Name = language.Name };
            return _languageRepo.Update(editLanguage);
            throw new NotImplementedException();
        }

        public LanguageViewModel FindBy(LanguageViewModel search)
        {

            throw new NotImplementedException();
        }

        public Language FindBy(int id)
        {
            return _languageRepo.Read(id);
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            Language language = _languageRepo.Read(id);
            if (language == null)
            {
                return false;

            }
            else
            {
                return _languageRepo.Delete(language);
            }

        }
    }
}
        

    



