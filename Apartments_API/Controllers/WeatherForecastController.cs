using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartments_API.Models;
using Apartments_API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IRepositoryWrapper _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<IsNaudotojas> Get()
        {
            return _repository.IsNaudotojas.FindAll();
        }
    }
}