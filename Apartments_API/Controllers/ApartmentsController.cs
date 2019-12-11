using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Cancels apartment's booking
        /// </summary>
        /// <param name="cancelDto">Cancellation data</param>
        /// <returns>Ok if cancelled, error response if not</returns>
        [HttpPost("book/cancel")]
        public IActionResult CancelBooking([FromBody] BookingCancelDto cancelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid booking cancellation data");
            }

            var cancelled = _repository.NuomosLaikotarpis.CancelReservation(cancelDto);
            if (!cancelled)
            {
                return BadRequest("Booking could not be cancelled");
            }

            return Ok();
        }
 
        /// <summary>
        /// Saves rating data
        /// </summary>
        /// <param name="ratingDto">Rating data</param>
        /// <returns>Rating if saved successfully, response error if not</returns>
        [HttpPost("rate")]
        public ActionResult<RatingDto> RateApartment([FromBody] RatingDto ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid rating data");
            }

            var savedRating = _repository.Butas.Rate(ratingDto);
            return Ok(_mapper.Map<Reitingas, RatingDto>(savedRating));
        }


        /// <summary>
        /// Delete apartment
        /// </summary>
        /// <param name="apartmentDeleteDto">Cancellation data</param>
        /// <returns>Ok if cancelled, error response if not</returns>
        [HttpPost("deleteApartment")]
        public IActionResult DeleteApartment([FromBody] ApartmentDeleteDto apartmentDeleteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid apartment deletion data");
            }

            var cancelled = _repository.Butas.Delete(apartmentDeleteDto);
            if (!cancelled)
            {
                return BadRequest("Apartment could not be cancelled");
            }

            return Ok();
        }


        /// <summary>
        /// Saves apartment in the db
        /// </summary>
        /// <param name="apartmentCreateDto">Apartnebt data</param>
        /// <returns>Apartment data if saved succesfully, badrequest error if not</returns>
        [HttpPost("addApartment")]
        public ActionResult<ApartmentDto> AddApartment([FromBody] ApartmentCreateDto apartmentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid apartment data");
            }
            var savedButas = _repository.Butas.Add(apartmentCreateDto);
            if (savedButas == null)
            {
                return BadRequest("Apartment could not be saved");
            }

            return Ok(_mapper.Map<Butas, ApartmentDto>(savedButas));
        }
        /// <summary>
        /// Saves apartment in the db
        /// </summary>
        /// <param name="apartmentCreateDto">Apartnebt data</param>
        /// <returns>Apartment data if saved succesfully, badrequest error if not</returns>
        [HttpPost("updateApartment")]
        public ActionResult<ApartmentDto> UpdateApartment([FromBody] ApartmentUpdateDto apartmentUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid apartment data");
            }
            _repository.Butas.Update(apartmentUpdateDto);


            return Ok();
        }
        /// <summary>
        /// Can search apartments by owner id or renter id
        /// </summary>
        /// <param name="searchDto">Search options</param>
        /// <returns>Found apartments</returns>
        [HttpPost("searchComplaints")]
        public ActionResult<IEnumerable<ApartmentDto>> SearchComplaints([FromBody] ApartmentsSearchDto searchDto)
        {
            if (searchDto.OwnerId == null && searchDto.TenantId == null)
            {
                return BadRequest("No search options");
            }

            var apartments = _repository.Skundas.Search(searchDto);
            if (!apartments.Any())
            {
                return NotFound("No complaints found");
            }

            return Ok(apartments);
        }
        // GET: api/apartment/report
        [HttpGet("report")]
        public IActionResult GenerateReport([FromBody] ReportDto reportData) // [FromBody] ReportDto reportData
        {
            var apartments = _repository.Butas.Search(reportData);
            //var mappedJobs = new List<RentIntervalDto>();

            //foreach (var job in bookings)
            //    mappedJobs.Add(_mapper.Map<NuomosLaikotarpis, RentIntervalDto>(job));

            var userData = _repository.IsNaudotojas
                .FindByCondition(o => o.IdIsNaudotojas == reportData.UserID)
                .FirstOrDefault();

            var userName = userData.Vardas;
            var userSurname = userData.Pavarde;

            decimal totalMoneyEarned = 0;
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0};{1}\n", userName, userSurname);
            sb.AppendLine("Data nuo;Data iki;");
            sb.AppendFormat("{0};{1};\n", reportData.From, reportData.To);
            sb.AppendLine("Apartment;Date of creation;Date of completion;Payment");

            foreach (var apartment in apartments)
            {
                decimal moneyEarned = 0;
                var bookings = _repository.NuomosLaikotarpis.Search(reportData, apartment.IdButas);
                var apartmentName = apartment.Pavadinimas;

                foreach (var book in bookings)
                {
                    if (book.Nuo != null && book.Iki != null)
                    {
                        int dateStartComparison = DateTime.Compare(reportData.From, (DateTime)book.Nuo);
                        int dateEndComparison = DateTime.Compare(reportData.To, (DateTime)book.Iki);
                        if (dateStartComparison <= 0 && dateEndComparison >= 0)
                        {
                            int days = (int) ((DateTime)book.Iki - (DateTime)book.Nuo).TotalDays;
                            moneyEarned += (decimal) (days * apartment.KainaUzNakti);
                        }
                    }
                }
                sb.AppendFormat("{0};{1};{2};{3}\n", apartmentName, reportData.From, reportData.To,
                                moneyEarned);
                totalMoneyEarned += moneyEarned;
            }



            sb.AppendFormat("{0};{1};{2};{3}\n", "", "", "Total Profit:", totalMoneyEarned);
            return File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "data.csv");
        }
    }
    
}