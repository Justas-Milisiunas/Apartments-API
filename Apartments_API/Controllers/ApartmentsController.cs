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
        public ActionResult<ApartmentDto> GetApartment(int id)
        {
            var foundApartment = _repository.Butas.FindByCondition(butas => butas.IdButas.Equals(id)).FirstOrDefault();
            if (foundApartment == null)
            {
                return NotFound("Apartment not found");
            }

            return Ok(_mapper.Map<Butas, ApartmentDto>(foundApartment));
        }

        /// <summary>
        /// Makes reservation for the apartment
        /// </summary>
        /// <param name="booking">Booking information</param>
        /// <returns>Booking reservation information</returns>
        [HttpPut("book")]
        public ActionResult<BookingDto> BookApartment([FromBody] BookingDto booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid booking information");
            }

            var reservation = _repository.NuomosLaikotarpis.CreateReservation(booking);
            if (reservation == null)
            {
                return Conflict("Those days are already rented");
            }

            return Ok(reservation);
        }

        /// <summary>
        /// Can search apartments by owner id or renter id
        /// </summary>
        /// <param name="searchDto">Search options</param>
        /// <returns>Found apartments</returns>
        [HttpPost("search")]
        public ActionResult<IEnumerable<ApartmentDto>> SearchApartments([FromBody] ApartmentsSearchDto searchDto)
        {
            if (searchDto.OwnerId == null && searchDto.TenantId == null)
            {
                return BadRequest("No search options");
            }

            var apartments = _repository.Butas.Search(searchDto);
            if (!apartments.Any())
            {
                return NotFound("No apartments found");
            }

            return Ok(apartments);
        }

        /// <summary>
        /// Saves complaint in the db
        /// </summary>
        /// <param name="complaintWriteDto">Complaint data</param>
        /// <returns>Complaint data if saved succesfully, badrequest error if not</returns>
        [HttpPost("complaint")]
        public ActionResult<ComplaintDto> WriteComplaint([FromBody] ComplaintWriteDto complaintWriteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid complaint data");
            }

            var savedComplaint = _repository.Skundas.WriteComplaint(complaintWriteDto);
            if (savedComplaint == null)
            {
                return BadRequest("Complaint could not be saved");
            }

            return Ok(_mapper.Map<Skundas, ComplaintDto>(savedComplaint));
        }
    }
}