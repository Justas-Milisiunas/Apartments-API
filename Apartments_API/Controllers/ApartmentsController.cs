using System.Collections.Generic;
using System.Linq;
using Apartments_API.DTO;
using Apartments_API.Models;
using Apartments_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/apartments")]
    public class ApartmentsController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ApartmentsController(IRepositoryWrapper repositoryWrapper,
            IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all apartments
        /// </summary>
        /// <returns>All apartments list</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ApartmentDto>> GetAllApartments()
        {
            var apartments = _repository.Butas.FindAll();
            var mappedApartments = new List<ApartmentDto>();
            foreach (var apartment in apartments)
            {
                mappedApartments.Add(_mapper.Map<Butas, ApartmentDto>(apartment));
            }

            return Ok(mappedApartments);
        }

        /// <summary>
        /// Gets apartment by given id
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <returns>If apartment not found returns bad request response, if found returns apartment</returns>
        [HttpGet("{id}")]
        public ActionResult<Butas> GetApartment(int id)
        {
            var foundApartment = _repository.Butas.FindByCondition(butas => butas.IdButas.Equals(id));
            if (foundApartment == null)
            {
                return NotFound("Apartment not found");
            }

            return Ok(foundApartment);
        }
    }
}