
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class Person
    {
        
        //Person-Data

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public Person() { }
        public Person(string name, City city, Country country, string phoneNumber)
        {
            
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
            Country = country;
        }


        /*public Person()
        {

            Id = id;
            Name = "göran";
            PhoneNumber = 153364153;
            Cities = "Stockholm";

        }*/

            
        
        

    }
}
