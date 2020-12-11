using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Types;

namespace MvcViewModels.Model
{ 
    public class CreatePersonViewModel
    { // Setting name dor user to understand better then just name to "Person name"
        [Display(Name ="Person Name")]
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Please put in right letters For Person Name")]
        public string Name { get; set; }
  
        [Display(Name ="City")]
        [Required]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "Please put in right letters For City")]
        public string City { get; set; }

        [Display(Name ="Phone Number")]
        [StringLength(15, ErrorMessage = "Please put in right numbers For Phone Number")]
        public string PhoneNumber { get; set; }


        //Use to prevent overposting and to use data  annotations to validate inputs when creating new person
    }
}
