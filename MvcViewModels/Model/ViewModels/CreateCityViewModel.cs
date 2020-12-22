using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcViewModels.Model
{
    public class CreateCityViewModel
    {
        public List<Country> CountryList { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }
    }
}
