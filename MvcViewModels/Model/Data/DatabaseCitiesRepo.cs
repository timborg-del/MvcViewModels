
using MvcViewModels.Model.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class DatabaseCitiesRepo : ICitysRepo
    {
        private readonly RegistryDbContext _citieDbContext;
        public DatabaseCitiesRepo(RegistryDbContext citieDbContext)
        {
            _citieDbContext = citieDbContext;
        }
        public City Create(string name)
        {
            City city = new City(name);

            _citieDbContext.CityList.Add(city);
            _citieDbContext.SaveChanges();
            return city;

            throw new NotImplementedException();
        }

        public bool Delete(City city)
        {
            _citieDbContext.CityList.Remove(city);
            _citieDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public List<City> Read()
        {
            return _citieDbContext.CityList.ToList();
            throw new NotImplementedException();
        }

        public City Read(int id)
        {
            return _citieDbContext.CityList.SingleOrDefault(CityList => CityList.Id == id);

            throw new NotImplementedException();
        }

        public City Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
