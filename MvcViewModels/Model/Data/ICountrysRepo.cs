
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public interface ICountrysRepo
    {

        //–Interface with following methods.
        Country Create(string name);
        List<Country> Read();
        Country Read(int id);
        Country Update(Country country);
        bool Delete(Country country);
    }
}
