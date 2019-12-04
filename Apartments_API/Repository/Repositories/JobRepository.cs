using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class JobRepository : IJobRepository
    {
        private RepositoryContext _context;

        public JobRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IEnumerable<Darbas> FindAll()
        {
            return _context.Set<Darbas>()
            .Include(o => o.DarboBusena)
            .AsNoTracking();
        }

        public IEnumerable<Darbas> FindByCondition(Expression<Func<Darbas, bool>> expression)
        {
            return _context.Set<Darbas>()
            .Where(expression)
            .Include(o => o.DarboBusena)
            .AsNoTracking();
        }

        public void Update(Darbas entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Darbas> MakeJobAsTaken(JobAcceptDto entity)
        {
            var job = _context.Set<Darbas>().Where(darbas => darbas.IdDarbas.Equals(entity.JobID));
            var tempJob = job.FirstOrDefault();
            tempJob.Busena = 2; // Change work state to - priimtas
            tempJob.FkValytojasidIsNaudotojas = entity.IsUserID;
            _context.SaveChangesAsync();

            return job.Include(o => o.DarboBusena).AsNoTracking();
        }

        public IEnumerable<Darbas> MakeJobAsDone(JobAcceptDto entity)
        {
            var job = _context.Set<Darbas>().Where(darbas => darbas.IdDarbas.Equals(entity.JobID));
            var tempJob = job.FirstOrDefault();
            tempJob.Busena = 1; // Change work state to - atliktas
            _context.SaveChangesAsync();

            return job.Include(o => o.DarboBusena).AsNoTracking();
        }

        public IEnumerable<Darbas> CancelJob(JobAcceptDto entity)
        {
            var job = _context.Set<Darbas>().Where(darbas => darbas.IdDarbas.Equals(entity.JobID));
            var tempJob = job.FirstOrDefault();
            tempJob.Busena = 3; // Change work state to laukiantis
            tempJob.FkValytojasidIsNaudotojas = null; // delete(worker)
            _context.SaveChangesAsync();

            return job.Include(o => o.DarboBusena).AsNoTracking();
        }

    }
}