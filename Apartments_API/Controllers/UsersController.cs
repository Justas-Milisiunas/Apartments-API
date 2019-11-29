using System.Collections.Generic;
using System.Linq;
using Apartments_API.DTO;
using Apartments_API.Models;
using Apartments_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryWrapper repositoryWrapper,
            ILogger<UsersController> logger,
            IMapper mapper)
        {
            _repository = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IEnumerable<IsNaudotojas> Index()
        {
            return _repository.IsNaudotojas.FindAll();
        }

        /// <summary>
        /// Saves user's data to database
        /// </summary>
        /// <param name="user">New user data</param>
        /// <returns>User data if user was saved successfully</returns>
        [HttpPost("register")]
        public ActionResult<UserDto> Register([FromBody] UserCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            // Checks if user does not exists
            var checkIfExists = _repository.IsNaudotojas
                .FindByCondition(o => o.ElPastas.ToLower().Equals(user.ElPastas.ToLower())).Any();
            if (checkIfExists)
            {
                return Conflict("User already exists");
            }

            // Saves user in db
            var createdUser = _repository.IsNaudotojas.Create(user);
            return Ok(_mapper.Map<IsNaudotojas, UserDto>(createdUser));
        }

        /// <summary>
        /// Checks given login information and returns user's data if logged in successfully
        /// </summary>
        /// <param name="user">Login data</param>
        /// <returns>User data if logged in successfully</returns>
        [HttpPost("login")]
        public ActionResult<UserDto> Login([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid login information");
            }

            var foundUser = _repository.IsNaudotojas
                .FindByCondition(o => o.ElPastas.Equals(user.ElPastas) && o.Slaptazodis.Equals(user.Slaptazodis))
                .FirstOrDefault();
            if (foundUser == null)
            {
                return NotFound("Bad login information");
            }

            return Ok(_mapper.Map<IsNaudotojas, UserDto>(foundUser));
        }
    }
}