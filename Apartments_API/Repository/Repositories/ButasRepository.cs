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
            return _repository.Set<Butas>().AsNoTracking();
        }

        public IEnumerable<Butas> FindByCondition(Expression<Func<Butas, bool>> expression)
        {
            return _repository.Set<Butas>().Where(expression).AsNoTracking();
        }

        public Butas Create(Butas entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Butas entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Butas entity)
        {
            throw new NotImplementedException();
        }
    }
}