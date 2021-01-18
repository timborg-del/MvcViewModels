using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public interface ILanguageRepo
    {


        //–Interface with following methods.
        Language Create(string name);
        List<Language> Read();
        Language Read(int id);
        Language Update(Language language);
        bool Delete(Language language);

    }
}




