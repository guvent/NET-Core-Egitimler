using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SehirRehberi.API.DataAccess.Abstract;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Helpers;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/cities/{cityId}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        private IOptions<CloudinarySettings> _cloudinaryOptions;

        private Cloudinary _cloudinary;

        public PhotosController(IAppRepository appRepository, IOptions<CloudinarySettings> cloudinaryOptions, IMapper mapper)
        {
            _appRepository = appRepository;
            _cloudinaryOptions = cloudinaryOptions;
            _mapper = mapper;

            Account account = new Account(_cloudinaryOptions.Value.CluodName, _cloudinaryOptions.Value.ApiKey, _cloudinaryOptions.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public ActionResult AddPhotoForCity(int cityId, [FromBody]PhotoForAddDto photoForAddDto)
        {
            var city = _appRepository.GetCityById(cityId);

            if (city == null) return BadRequest("Couldn't find the city!");

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentUserId != city.UserId) return Unauthorized();

            var file = photoForAddDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length>0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForAddDto.Url = uploadResult.Uri.ToString();
            photoForAddDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForAddDto);
            photo.City = city;

            if (!city.Photos.Any(p => p.IsMain)) photo.IsMain = true;

            city.Photos.Add(photo);

            if (_appRepository.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForGetDto>(photo);
                return CreatedAtRoute("GetPhoto", new {id = photo.Id}, photoToReturn);
            }

            return BadRequest("Couldn't add photo!");
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public ActionResult GetPhoto(int id)
        {
            var photoFromDb = _appRepository.GetPhoto(id);
            var photo = _mapper.Map<PhotoForGetDto>(photoFromDb);

            return Ok(photo);
        }
    }
}