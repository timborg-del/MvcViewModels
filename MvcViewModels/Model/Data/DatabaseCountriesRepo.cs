
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
            _countrieDbContext.SaveChanges();
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
