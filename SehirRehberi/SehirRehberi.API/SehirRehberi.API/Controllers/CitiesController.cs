using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.DataAccess;
using SehirRehberi.API.DataAccess.Abstract;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            // Automapper dan önce....
            //var cities = _appRepository.GetCities().Select(c=>new CityForListDto
            //{
            //    Id = c.Id,
            //    Description = c.Description,
            //    Name = c.Name,
            //    PhotoUrl = c.Photos.FirstOrDefault(p=>p.IsMain).Url
            //}).ToList();

            // Automapper dan sonra....

            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            return Ok(citiesToReturn);

        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityForReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityForReturn);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosCity(int cityId)
        {
            var photos = _appRepository.GetPhotosCity(cityId);
            return Ok(photos);
        }
    }
}