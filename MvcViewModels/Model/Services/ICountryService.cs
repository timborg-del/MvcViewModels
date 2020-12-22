using MvcViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Services
{
    public interface ICountryService
    {
        //Interface with following methods.
        Country Add(CreateCountryViewModel createCountryViewModel);
        CountryViewModel All();
        CountryViewModel FindBy(CreateCountryViewModel search);
        Country FindBy(int id);
        Country Edit(int id, CreateCountryViewModel country);
        bool Remove(int id);

    }
}

