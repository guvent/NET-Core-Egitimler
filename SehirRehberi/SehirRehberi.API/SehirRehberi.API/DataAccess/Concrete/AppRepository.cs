using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.DataAccess.Abstract;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.DataAccess.Concrete
{
    public class AppRepository:IAppRepository
    {
        private DataContext _dataContext;

        public AppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public List<City> GetCities()
        {
            return _dataContext.Cities.Include(c => c.Photos).ToList();
        }

        public List<Photo> GetPhotosCity(int id)
        {
            return _dataContext.Photos.Where(p => p.CityId == id).ToList();
        }

        public City GetCityById(int cityId)
        {
            return _dataContext.Cities.Include(c=>c.Photos).FirstOrDefault(c => c.Id == cityId);
        }

        public Photo GetPhoto(int id)
        {
            return _dataContext.Photos.FirstOrDefault(p => p.Id == id);
        }
    }
}
