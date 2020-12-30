
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public interface ICitysRepo
    {           
        //–Interface with following methods.
        City Create(string name, Country country);
        List<City> Read();
        City Read(int id);
        City Update(City city);
        bool Delete(City city);
    }
}

