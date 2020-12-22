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
        public List<Person> People { get; set; }
        [Display(Name = "Country Name")]
        [Required]
        
        public string Name { get; set; }

    }
}
