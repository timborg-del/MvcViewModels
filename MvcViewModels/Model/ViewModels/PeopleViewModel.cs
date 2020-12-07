using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class PeopleViewModel
    {
        
        //public Person person = new Person();
        public List<Person> personList = new List<Person>();


        public PeopleViewModel()
        {

            personList = new List<Person>();
           
        }

        //List<Person>
        //container for the information you need in yourpeopleview.
    }
}
