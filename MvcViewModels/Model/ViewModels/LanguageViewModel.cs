using System;
using System.Collections.Generic;
using System.Linq;
using MvcViewModels.Model.Data;
using System.Threading.Tasks;

namespace MvcViewModels.Model
{
    public class LanguageViewModel
    {
        public List<Language> LanguagesList = new List<Language>();


        public LanguageViewModel()
        {

            LanguagesList = new List<Language>();

        }
    }
}
  