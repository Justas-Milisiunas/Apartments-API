using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class ButasRepository : IButasRepository
    {
        private RepositoryContext _repository;

        public ButasRepository(RepositoryContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IEnumerable<Butas> FindAll()
        {
            return _repository.Set<Butas>()
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking();
        }

        public IEnumerable<Butas> FindByCondition(Expression<Func<Butas, bool>> expression)
        {
            return _repository.Set<Butas>().Where(expression)
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking();
        }

        public void Update(Butas entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Butas entity)
        {
            throw new NotImplementedException();
        }
    }
}