using System.Collections.Generic;
using Apartments_API.Models;
using Apartments_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public JobsController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        // GET: api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<Darbas>> GetAllJobs()
        {
            return Ok(_repository.Job.FindAll());
        }

        // GET: api/jobs/1
        [HttpGet("{id}")]
        public ActionResult<Darbas> GetJob(int id)
        {
            var foundJob = _repository.Job.FindByCondition(job => job.IdDarbas.Equals(id));
            if (foundJob == null)
                return NotFound("Job not found");
            return Ok(foundJob);
        }
    }
}