using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;

namespace Apartments_API.Repository.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private RepositoryContext _repository;

        public ComplaintRepository(RepositoryContext repository)
        {
            _repository = repository;
        }

        public IEnumerable<Skundas> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skundas> FindByCondition(Expression<Func<Skundas, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Skundas entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Skundas WriteComplaint(ComplaintWriteDto complaintDto)
        {
            var isUserRentingApartment = _repository.Set<NuomosLaikotarpis>().Any(o =>
                o.FkNuomininkasidIsNaudotojas.Equals(complaintDto.FkNuomininkasidIsNaudotojas) &&
                o.FkButasidButas.Equals(complaintDto.FkButasidButas));
            if (!isUserRentingApartment)
            {
                return null;
            }

            var complaint = _repository.Mapper.Map<ComplaintWriteDto, Skundas>(complaintDto);
            _repository.Set<Skundas>().Add(complaint);
            _repository.SaveChanges();

            return complaint;
        }
    }
}