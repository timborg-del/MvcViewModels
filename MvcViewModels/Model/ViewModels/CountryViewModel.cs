using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcViewModels.Model;
using MvcViewModels.Model.Services;


namespace MvcViewModels.Model
{
    public class CountryViewModel
    {

        //public Person person = new Person();
        public List<Country> countrieList = new List<Country>();


        public CountryViewModel()
        {

            countrieList = new List<Country>();

        }
    }
}
