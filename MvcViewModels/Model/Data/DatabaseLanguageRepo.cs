
using Microsoft.EntityFrameworkCore;
using MvcViewModels.Model.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class DatabaseLanguage : ILanguageRepo
    {
        private readonly RegistryDbContext _languaDbContext;
        public DatabaseLanguage(RegistryDbContext languaDbContrext)
        {
            _languaDbContext = languaDbContrext;
        }
        public Language Create(string name)
        {
            Language language = new Language(name);

            _languaDbContext.LanguagesList.Add(language);
            _languaDbContext.SaveChanges();
            return language;

            throw new NotImplementedException();
        }

        public bool Delete(Language language)
        {
            _languaDbContext.LanguagesList.Remove(language);
            int rowsEffected = _languaDbContext.SaveChanges();
            if (rowsEffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Language> Read()
        {
            return _languaDbContext.LanguagesList.ToList();

        }

        public Language Read(int id)
        {
            return _languaDbContext.LanguagesList.SingleOrDefault(LanguageList => LanguageList.Id == id);
            // return _citieDbContext.LanguageList.SingleOrDefault(LanguageList => LanguageList.Id == id);


        }

        public Language Update(Language language)
        {
            _languaDbContext.LanguagesList.Update(language);
            //Language updateLanguage = Read(language.Id);

            if (_languaDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;

            //updateLanguage.Name = language.Name;
            ////updateLanguage.Languages = language.Languages;

            //_languaDbContext.SaveChanges();
            //return _languaDbContext.LanguagesList.SingleOrDefault(languageList => languageList.Id == language.Id);


        }
    }
}
    


