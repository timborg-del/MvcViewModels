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
        public string City { get; set; }
        public Person() { }
        public Person(string name, string city, string phoneNumber)
        {
            
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public Person(int id, string name, string city, string phoneNumber) : this(name, city, phoneNumber)
        {
            Id = id;
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
