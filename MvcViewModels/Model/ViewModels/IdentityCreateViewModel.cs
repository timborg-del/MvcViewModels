using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvcViewModels.Model.Data;
using Microsoft.AspNetCore.Identity;

namespace MvcViewModels.Model
{
    public class IdentityCreateViewModel
    {
        [Required]
        [StringLength(18, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 3)]
        public string LastName { get; set; }


        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must Contain 6 letters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ControlPassword { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


    }
}
