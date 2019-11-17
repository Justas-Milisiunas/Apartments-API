using System.Collections.Generic;
using Apartments_API.DTO;
using Apartments_API.Models;
using Apartments_API.Repository;
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

        public UsersController(IRepositoryWrapper repositoryWrapper, ILogger<UsersController> logger)
        {
            _repository = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet("all")]
        public IEnumerable<IsNaudotojas> Index()
        {
            return _repository.IsNaudotojas.FindAll();
        }

        [HttpPost("register")]
        public ActionResult<IsNaudotojas> Register([FromBody] UserCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var createdUser = _repository.IsNaudotojas.Create(new IsNaudotojas(user));
            // TODO: Add user to one of the roles table
            switch (user.Role)
            {
            }

            return Ok();
        }
    }
}