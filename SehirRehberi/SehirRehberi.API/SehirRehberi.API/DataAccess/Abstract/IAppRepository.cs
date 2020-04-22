using System.Collections.Generic;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.DataAccess.Abstract
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosCity(int id);
        City GetCityById(int cityId);
        Photo GetPhoto(int id);

    }
}
