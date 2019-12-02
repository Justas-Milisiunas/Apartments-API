using System;
using System.IO;
using Apartments_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotosController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PhotosController(IRepositoryWrapper repositoryWrapper,
            IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns image by given id
        /// </summary>
        /// <param name="id">Image id</param>
        /// <returns>Found image</returns>
        [HttpGet("{id}")]
        public IActionResult GetPhoto(string id)
        {
            try
            {
                var image = System.IO.File.OpenRead("Data//Photos//" + id);
                return File(image, "image/jpeg");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }
}