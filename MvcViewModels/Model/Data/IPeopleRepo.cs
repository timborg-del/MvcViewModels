
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model.Data;

namespace MvcViewModels.Model
{
    public interface IPeopleRepo
    {
     
        //–Interface with following methods.
        Person Create(string name, City city, Country country, string phoneNumber);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
     
    }
}
