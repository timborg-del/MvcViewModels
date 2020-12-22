using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class CityViewModel
    {
        //public Person person = new Person();
        public List<City> cityList = new List<City>();


        public CityViewModel()
        {

            cityList = new List<City>();

        }
    }
}
