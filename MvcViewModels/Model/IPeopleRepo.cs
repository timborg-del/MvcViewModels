using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    interface IPeopleRepo
    {

        //–Interface with following methods.
        //▪bool Create(“parameters needed to create Person excluding id”)
        //▪List<Person> Read()
        //▪Person Read(int id)
        //▪Person Update(Person person)
        //▪Bool Delete(Person person)
    }
}
