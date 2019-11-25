using System.Collections.Generic;
using Apartments_API.Models;
using Apartments_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/apartments")]
    public class ApartmentsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public ApartmentsController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        /// <summary>
        /// Gets all apartments
        /// </summary>
        /// <returns>All apartments list</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Butas>> GetAllApartments()
        {
            return Ok(_repository.Butas.FindAll());
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