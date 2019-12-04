using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartments_API.DTO;
using Apartments_API.Models;
using Apartments_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<JobDto>> GetAllJobs()
        {
            var jobs = _repository.Job.FindAll();
            var mappedJobs = new List<JobDto>();
            foreach (var job in jobs)
                mappedJobs.Add(_mapper.Map<Darbas, JobDto>(job));

            return Ok(mappedJobs);
        }

        // GET: api/jobs/1
        [HttpGet("{id}")]
        public ActionResult<JobDto> GetJob(int id)
        {
            var foundJob = _repository.Job.FindByCondition(job => job.IdDarbas.Equals(id)).FirstOrDefault();
            var tempJob = new Darbas();
            if (foundJob == null)
                return NotFound("Job not found");

            var retJob = _mapper.Map<Darbas, JobDto>(foundJob);
            return Ok(retJob);
        }

        // PUT: api/jobs/accept
        [HttpPut("accept")]
        public ActionResult<JobDto> AcceptWork([FromBody] JobAcceptDto job)
        {
            if (!ModelState.IsValid)
                return NotFound("Invalid acceptWork data");

            var changedJob = _repository.Job.MakeJobAsTaken(job).FirstOrDefault();
            var retJob = _mapper.Map<Darbas, JobDto>(changedJob);
            return Ok(retJob);
        }

        // PUT: api/jobs/done
        [HttpPut("done")]
        public ActionResult<JobDto> FinishWork([FromBody] JobAcceptDto job)
        {
            if (!ModelState.IsValid)
                return NotFound("Invalid acceptWork data");

            var changedJob = _repository.Job.MakeJobAsDone(job).FirstOrDefault();
            var retJob = _mapper.Map<Darbas, JobDto>(changedJob);
            return Ok(retJob);
        }

        [HttpPut("delete")]
        public ActionResult<JobDto> CancelTakenJob([FromBody] JobAcceptDto job)
        {
            if (!ModelState.IsValid)
                return NotFound("Invalid acceptWork data");

            var changedJob = _repository.Job.CancelJob(job).FirstOrDefault();
            var retJob = _mapper.Map<Darbas, JobDto>(changedJob);
            return Ok(retJob);
        }

        // GET: api/history
        [HttpGet("history/{id}")]
        public ActionResult<IEnumerable<JobDto>> GetHistoryJobs(int id)
        {
            var jobs = _repository.Job.FindHistory(id);
            var mappedJobs = new List<JobDto>();
            foreach (var job in jobs)
                mappedJobs.Add(_mapper.Map<Darbas, JobDto>(job));

            return Ok(mappedJobs);
        }

        // TODO: 
        // AtaskaitosGeneravimas
    }
}