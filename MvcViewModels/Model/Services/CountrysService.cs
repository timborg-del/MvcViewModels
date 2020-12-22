
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Services
{


    public class CountrysService : ICountryService
    {
        //–Implements ICountrysService interface
        private readonly ICountrysRepo _countriesRepo;

        public CountrysService(ICountrysRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }
        public Country Add(CreateCountryViewModel createCountryViewModel)
        {

            return _countriesRepo.Create(createCountryViewModel.Name);

        }

        public CountryViewModel All()
        {
            CountryViewModel countrysViewModel = new CountryViewModel();
            //InMemoryCountrysRepo _caresRepo = new InMemoryCountrysRepo();
            countrysViewModel.countrieList = _countriesRepo.Read();
            ///countrysViewModel.countryList 

            return countrysViewModel;

        }

        public Country Edit(int id, CreateCountryViewModel country)
        {
            Country editCountry = new Country() {Name=country.Name, Id=id };
             return _countriesRepo.Update(editCountry);
            
            throw new NotImplementedException();
        }

        public CountryViewModel FindBy(CreateCountryViewModel search)
        {
            //CountryViewModel
            //return _countriesRepo.Read();
            throw new NotImplementedException();
        }

        public Country FindBy(int id)
        {
            return _countriesRepo.Read(id);

            //throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            Country country = _countriesRepo.Read(id);
            if (country == null)
            {
                return false;

            }
            else
            {
                return _countriesRepo.Delete(country);
            }

        }
    }

}



