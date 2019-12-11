using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;
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
                .Include(o => o.FkButasidButasNavigation)
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

            if (tempJob.Busena != 3)
                return Enumerable.Empty<Darbas>();

            tempJob.Busena = 2; // Change work state to - priimtas
            tempJob.FkValytojasidIsNaudotojas = entity.IsUserID;

            _context.SaveChanges();

            return job.Include(o => o.DarboBusena).Include(o => o.FkButasidButasNavigation).AsNoTracking();
        }

        public IEnumerable<Darbas> MakeJobAsDone(JobAcceptDto entity)
        {
            var job = _context.Set<Darbas>().Where(darbas => darbas.IdDarbas.Equals(entity.JobID));
            var user = _context.Set<IsNaudotojas>().Where(user => user.IdIsNaudotojas.Equals(entity.IsUserID));
            var tempJob = job.FirstOrDefault();
            var tempUser = user.FirstOrDefault();

            if (tempJob.Busena == 2)
            {
                tempJob.Busena = 1; // Change work state to - atliktas
                tempJob.FkValytojasidIsNaudotojas = entity.IsUserID;
                tempUser.Balansas += tempJob.Uzmokestis;

                tempJob.IvykdymoData = DateTime.Now;
                _context.SaveChanges();

                return job.Include(o => o.DarboBusena).AsNoTracking();
            }
            else
                return null;
        }

        public IEnumerable<Darbas> CancelJob(JobAcceptDto entity)
        {
            var job = _context.Set<Darbas>().Where(darbas => darbas.IdDarbas.Equals(entity.JobID));
            var tempJob = job.FirstOrDefault();

            if (tempJob.Busena != 2)
                return Enumerable.Empty<Darbas>();

            tempJob.Busena = 3; // Change work state to laukiantis
            tempJob.FkValytojasidIsNaudotojas = null; // delete(worker)

            _context.SaveChanges();

            return job.Include(o => o.DarboBusena).AsNoTracking();
        }

        public IEnumerable<Darbas> FindHistory(int id)
        {
            return _context.Set<Darbas>()
                .Where(o => o.FkValytojasidIsNaudotojas == id && o.Busena == 1)
                .Include(o => o.DarboBusena)
                .Include(o => o.FkButasidButasNavigation)
                .AsNoTracking();
        }

        public IEnumerable<Darbas> FindDataToReport(int id)
        {
            return _context.Set<Darbas>()
                .Where(o => o.FkValytojasidIsNaudotojas == id)
                .Include(o => o.FkButasidButasNavigation)
                .AsNoTracking();
        }
    }
}