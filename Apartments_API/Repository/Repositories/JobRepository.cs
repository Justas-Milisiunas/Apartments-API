using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class JobRepository : IJobRepository
    {
        private RepositoryContext _repository;
        public JobRepository(RepositoryContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IEnumerable<Darbas> FindAll()
        {
            return _repository.Set<Darbas>().AsNoTracking();
        }

        public IEnumerable<Darbas> FindByCondition(Expression<Func<Darbas, bool>> expression)
        {
            return _repository.Set<Darbas>().Where(expression).AsNoTracking();
        }

        public void Update(Darbas entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Darbas entity)
        {
            throw new NotImplementedException();
        }
    }
}