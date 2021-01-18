using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MvcViewModels.Model.Data
{
    public class CreateLanguageViewModel
    {
        public List<Language> Languages { get; set; }
       
        [Display(Name = "Languages")]
        public string Name { get; set; }

        [Display(Name = "Language")]
       // [Required]
        public Language Language { get; set; }

    }
}
