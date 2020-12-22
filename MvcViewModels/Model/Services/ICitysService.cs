using MvcViewModels.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Services
{
    public interface ICitysService
    {

        //Interface with following methods.
        City Add(CreateCityViewModel createCityViewModel);
        CityViewModel All();
        CityViewModel FindBy(CityViewModel search);
        City FindBy(int id);
        City Edit(int id, CreateCityViewModel country);
        bool Remove(int id);


    }

}

