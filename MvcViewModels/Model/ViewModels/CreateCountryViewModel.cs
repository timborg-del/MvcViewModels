using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Types;
namespace MvcViewModels.Model
{
    public class CreateCountryViewModel
    {
        public List<Country> CountryList { get; set; }
        public List<City> Cities { get; set; }
        [Display(Name = "Country")]
        [Required]
       
        
        public string Name { get; set; }

    }
}
