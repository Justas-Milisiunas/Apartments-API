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
                // Owner
                case 0:
                    var owner = new Savininkas();
                    owner.IdIsNaudotojas = user.IdIsNaudotojas;
                    _repository.Set<Savininkas>().Add(owner);
                    break;
                // Tenant
                case 1:
                    var tenant = new Nuomininkas();
                    tenant.IdIsNaudotojas = user.IdIsNaudotojas;
                    _repository.Set<Nuomininkas>().Add(tenant);
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

        public IsNaudotojas Update(UserUpdateDto userUpdateDto)
        {
            var foundUser = _repository
                .Set<IsNaudotojas>()
                .FirstOrDefault(o => o.IdIsNaudotojas.Equals(userUpdateDto.IdIsNaudotojas) && o.Slaptazodis.Equals(userUpdateDto.Slaptazodis));

            if (foundUser == null)
            {
                return null;
            }

            foundUser.Vardas = userUpdateDto.Vardas;
            foundUser.Pavarde = userUpdateDto.Pavarde;
            foundUser.ElPastas = userUpdateDto.ElPastas;
            
            if (!string.IsNullOrEmpty(userUpdateDto.NaujasSlaptazodis))
            {
                foundUser.Slaptazodis = userUpdateDto.NaujasSlaptazodis;
            }

            _repository.SaveChanges();
            return foundUser;
        }

        public bool Delete(int id)
        {
            var userExists = _repository.Set<IsNaudotojas>().Where(o => o.IdIsNaudotojas.Equals(id)).Any();
            if (!userExists)
            {
                return false;
            }
            _repository.Set<IsNaudotojas>().Remove(new IsNaudotojas
            {
                IdIsNaudotojas = id
            });
            _repository.SaveChanges();

            return true;
        }
        
        public void Update(IsNaudotojas entity)
        {
            throw new NotImplementedException();
        }
    }
}