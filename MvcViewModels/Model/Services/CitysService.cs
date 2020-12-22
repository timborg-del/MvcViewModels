using MvcViewModels.Model.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Model.Services
{
    public class CitysService : ICitysService
    {
        private readonly ICitysRepo _citysRepo;
        
        public CitysService(ICitysRepo citysRepo)
        {
            _citysRepo = citysRepo;
        }
        public City Add(CreateCityViewModel createCityViewModel)
        {
            return _citysRepo.Create(createCityViewModel.Name);
            throw new NotImplementedException();
        }

        public CityViewModel All()
        {
            CityViewModel cityViewMode = new CityViewModel();
            cityViewMode.cityList = _citysRepo.Read();

            return cityViewMode;
            //throw new NotImplementedException();
        }

        public City Edit(int id, CreateCityViewModel city)
        {
            City editCity = new City() { Id = id, Name = city.Name };
            return _citysRepo.Update(editCity);
            throw new NotImplementedException();
        }

        public CityViewModel FindBy(CityViewModel search)
        {

            throw new NotImplementedException();
        }

        public City FindBy(int id)
        {
            return _citysRepo.Read(id);
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            City city = _citysRepo.Read(id);
            if (city == null)
            {
                return false;

            }
            else
            {
                return _citysRepo.Delete(city);
            }

        }
    }

}

