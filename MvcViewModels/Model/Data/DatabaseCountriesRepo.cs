
using MvcViewModels.Model.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class DatabaseCountrysRepo : ICountrysRepo
    {
        private readonly RegistryDbContext _countrieDbContext;
        public DatabaseCountrysRepo(RegistryDbContext countrieDbContext)
        {
            _countrieDbContext = countrieDbContext;
        }
        public Country Create(string name)
        {
            Country country = new Country(name);

            _countrieDbContext.CountrieList.Add(country);
            _countrieDbContext.SaveChanges();
            return country;

            
        }

        public bool Delete(Country country)
        {
            _countrieDbContext.CountrieList.Remove(country);
           int rowsEffected = _countrieDbContext.SaveChanges();

            if (rowsEffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public List<Country> Read()
        {

            return _countrieDbContext.CountrieList.ToList();
            throw new NotImplementedException();

        }

        public Country Read(int id)
        {
            return _countrieDbContext.CountrieList.SingleOrDefault(countrieList => countrieList.Id == id);
            throw new NotImplementedException();
        }

        public Country Update(Country country)
        {
            Country updateCountrie = Read(country.Id);

            if (updateCountrie == null)
            {
                return null;
            }

            updateCountrie.Id = country.Id;
            updateCountrie.Name = country.Name;
            updateCountrie.Cities = country.Cities;
            

            _countrieDbContext.SaveChanges();

            return _countrieDbContext.CountrieList.SingleOrDefault(countrieList => countrieList.Id == country.Id);
            throw new NotImplementedException();
        }
    }
}
