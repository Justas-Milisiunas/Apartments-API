using System.Collections.Generic;
using Apartments_API.DTO;
using Apartments_API.Models;
using Apartments_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apartments_API.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public JobsController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        // GET: api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<Darbas>> GetAllJobs()
        {
            var jobs = _repository.Job.FindAll();
            var mappedJobs = new List<JobDto>();
            foreach (var job in jobs)
                mappedJobs.Add(_mapper.Map<Darbas, JobDto>(job));

            return Ok(mappedJobs);
        }

        // GET: api/jobs/1
        [HttpGet("{id}")]
        public ActionResult<Darbas> GetJob(int id)
        {
            var foundJob = _repository.Job.FindByCondition(job => job.IdDarbas.Equals(id));
            var tempJob = new Darbas();
            if (foundJob == null)
                return NotFound("Job not found");
            else
            {
                foreach (var job in foundJob)
                    tempJob = job;
                var retJob = _mapper.Map<Darbas, JobDto>(tempJob);
                return Ok(retJob);
            }
        }
    }
}