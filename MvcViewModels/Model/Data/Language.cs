using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class Language
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<PersonLanguage> Persons { get; set; }
        public Language()
        {

        }
        public Language(string name)
        {
            Name = name;
        }
    }

}

