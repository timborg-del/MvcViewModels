using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class PersonLanguage
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
       

        public PersonLanguage()
        {

        }
    }
}
