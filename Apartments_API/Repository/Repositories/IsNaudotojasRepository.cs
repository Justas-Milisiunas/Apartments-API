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
            return _repository.Set<IsNaudotojas>()
                .Where((expression))
                .Include(o => o.Savininkas)
                .Include(o => o.Valytojas)
                .Include(o => o.Nuomininkas)
                .AsNoTracking();
        }

        public IsNaudotojas Create(UserCreateDto entity)
        {
            var user = _repository.Mapper.Map<UserCreateDto, IsNaudotojas>(entity);
            _repository.Set<IsNaudotojas>().Add(user);
            _repository.SaveChanges();

            // Saves in one of the roles table
            var role = entity.Role;
            switch (role)
            {
                // Tenant
                case 0:
                    var tenant = new Nuomininkas();
                    tenant.IdIsNaudotojas = user.IdIsNaudotojas;
                    _repository.Set<Nuomininkas>().Add(tenant);
                    break;
                // Owner
                case 1:
                    var owner = new Savininkas();
                    owner.IdIsNaudotojas = user.IdIsNaudotojas;
                    _repository.Set<Savininkas>().Add(owner);
                    break;
                // Worker
                case 2:
                    var worker = new Valytojas();
                    worker.IdIsNaudotojas = user.IdIsNaudotojas;
                    _repository.Set<Valytojas>().Add(worker);
                    break;
            }

            _repository.SaveChanges();
            return user;
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