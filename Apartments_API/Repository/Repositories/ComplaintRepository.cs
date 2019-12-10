using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Skundas> Search(ApartmentsSearchDto searchDto)
        {
            // TODO: add null check to new search options
            var complaints = _repository.Set<Skundas>()
                .Include(o => o.FkButasidButasNavigation)
                .AsNoTracking().AsEnumerable();

           /* var apartments = _repository.Set<Butas>()
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking().AsEnumerable();
            */
            var foundComplaints = new List<Skundas>();
            foreach (var complaint in complaints)
            {
                if ((searchDto.OwnerId != null && complaint.FkButasidButasNavigation.FkSavininkasidIsNaudotojas == searchDto.OwnerId))
                {
                    foundComplaints.Add(complaint);
                }
            }

            return foundComplaints;
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