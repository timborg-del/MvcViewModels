using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class City
    {
 

        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public List<Person> Citiezens { get; set; }

        
        public City() { }
        public City(string name)
        {
          
            Name = name;

        }
        
    }
}


