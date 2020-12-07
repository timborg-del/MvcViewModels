using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    interface IPeopleRepo
    {

        //–Interface with following methods.
        Person Create(string name, string city, int phoneNumber);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
