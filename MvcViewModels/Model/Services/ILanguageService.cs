using MvcViewModels.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Services
{
    public interface ILanguageService
    {

        Language Add(CreateLanguageViewModel createCityViewModel);
        LanguageViewModel All();
        LanguageViewModel FindBy(LanguageViewModel search);
        Language FindBy(int id);
        Language Edit(int id, CreateLanguageViewModel language);
        bool Remove(int id);





    }
}
