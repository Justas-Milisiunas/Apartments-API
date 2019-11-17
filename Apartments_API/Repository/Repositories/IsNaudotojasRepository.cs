using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class IsNaudotojasRepository : IIsNaudotojasRepository
    {
        private RepositoryContext _repository;

        public IsNaudotojasRepository(RepositoryContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IEnumerable<IsNaudotojas> FindAll()
        {
            return _repository.Set<IsNaudotojas>()
                .Include(o => o.Savininkas)
                .Include(o => o.Valytojas)
                .Include(o => o.Nuomininkas)
                .AsNoTracking();
        }

        public IEnumerable<IsNaudotojas> FindByCondition(Expression<Func<IsNaudotojas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IsNaudotojas Create(IsNaudotojas entity)
        {
            var createdUser = _repository.Set<IsNaudotojas>().Add(entity).Entity;
            _repository.SaveChanges();
            return createdUser;
        }

        public void Update(IsNaudotojas entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IsNaudotojas entity)
        {
            throw new NotImplementedException();
        }
    }
}