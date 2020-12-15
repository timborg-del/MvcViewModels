using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public interface IPeopleService
    {
        //Interface with following methods.
        Person Add(CreatePersonViewModel createPersonViewModel);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person FindBy(int id);
        Person Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);

    }
}
