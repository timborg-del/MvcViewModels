
using Microsoft.EntityFrameworkCore;
using MvcViewModels.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Data
{
    public class DatabaseCitiesRepo : ICitysRepo
    {
        private readonly IdentityPersonDbContext _citieDbContext;
        public DatabaseCitiesRepo(IdentityPersonDbContext citieDbContext)
        {
            _citieDbContext = citieDbContext;
        }
        public City Create(string name, Country country)
        {
            City city = new City(name, country);

            _citieDbContext.CityList.Add(city);
            _citieDbContext.SaveChanges();
            return city;

            throw new NotImplementedException();
        }

        public bool Delete(City city)
        {
            _citieDbContext.CityList.Remove(city);
          int rowsEffected =  _citieDbContext.SaveChanges();
            if (rowsEffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }

        public List<City> Read()
        {
            return _citieDbContext.CityList.ToList();
           
        }

        public City Read(int id)
        {
            return _citieDbContext.CityList.Include(c => c.Citiezens).SingleOrDefault(CityList => CityList.Id == id);
           // return _citieDbContext.CityList.SingleOrDefault(CityList => CityList.Id == id);

            
        }

        public City Update(City city)
        {
            City updateCity = Read(city.Id);

            if (updateCity == null)
            {
                return null;
            }

            updateCity.Name = city.Name;
            updateCity.Countries = city.Countries;

            _citieDbContext.SaveChanges();
            return _citieDbContext.CityList.SingleOrDefault(cityList => cityList.Id == city.Id);

            
        }
    }
}
