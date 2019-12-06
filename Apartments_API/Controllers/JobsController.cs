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
            if (changedJob == null)
            {
                return BadRequest("Job is already taken or it is done");
            }

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
            if (changedJob == null)
                return BadRequest("Job is already done or it is not taken by this user");
            var retJob = _mapper.Map<Darbas, JobDto>(changedJob);
            return Ok(retJob);
        }

        // PUT: api/jobs/delete
        [HttpPut("delete")]
        public ActionResult<JobDto> CancelTakenJob([FromBody] JobAcceptDto job)
        {
            if (!ModelState.IsValid)
                return NotFound("Invalid acceptWork data");

            var changedJob = _repository.Job.CancelJob(job).FirstOrDefault();
            if (changedJob == null)
                return BadRequest("Job is already done or it is not taken by this user");

            var retJob = _mapper.Map<Darbas, JobDto>(changedJob);
            return Ok(retJob);
        }

        // GET: api/jobs/history
        [HttpGet("history/{id}")]
        public ActionResult<IEnumerable<JobDto>> GetHistoryJobs(int id)
        {
            var jobs = _repository.Job.FindHistory(id);
            var mappedJobs = new List<JobDto>();

            foreach (var job in jobs)
                mappedJobs.Add(_mapper.Map<Darbas, JobDto>(job));

            return Ok(mappedJobs);
        }

        // GET: api/jobs/report
        [HttpGet("report")]
        public IActionResult GenerateReport([FromBody] ReportDto reportData) // [FromBody] ReportDto reportData
        {
            var jobs = _repository.Job.FindDataToReport(reportData.UserID);
            var mappedJobs = new List<JobDto>();
            
            foreach (var job in jobs)
                mappedJobs.Add(_mapper.Map<Darbas, JobDto>(job));
            
            var userData = _repository.IsNaudotojas
                .FindByCondition(o => o.IdIsNaudotojas == reportData.UserID)
                .FirstOrDefault();
            
            var userName = userData.Vardas;
            var userSurname = userData.Pavarde;

            decimal moneyEarned = 0;
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0};{1}\n", userName, userSurname);
            sb.AppendLine("Data nuo;Data iki;");
            sb.AppendFormat("{0};{1};\n", reportData.From, reportData.To);
            sb.AppendLine("Apartment;Date of creation;Date of completion;Payment");
            
            foreach (var job in mappedJobs)
            {
                if (job.SukurimoData != null && job.IvykdymoData != null)
                {
                    int dateStartComparison = DateTime.Compare(reportData.From, (DateTime) job.SukurimoData);
                    int dateEndComparison = DateTime.Compare(reportData.To, (DateTime) job.IvykdymoData);
                    if (dateStartComparison <= 0 && dateEndComparison >= 0)
                    {
                        var apartmentName = job.Butas.Pavadinimas;
                        sb.AppendFormat("{0};{1};{2};{3}\n", apartmentName, job.SukurimoData, job.IvykdymoData,
                            job.Uzmokestis);
                        moneyEarned += (decimal) job.Uzmokestis;
                    }
                }
            }

            sb.AppendFormat("{0};{1};{2};{3}\n", "", "", "Profit:", moneyEarned);
            return File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "data.csv");
        }
    }
}