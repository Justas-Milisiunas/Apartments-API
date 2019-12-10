using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class NuomosLaikotarpisRepository : INuomosLaikotarpisRepository
    {
        private RepositoryContext _repository;

        public NuomosLaikotarpisRepository(RepositoryContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IEnumerable<NuomosLaikotarpis> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NuomosLaikotarpis> FindByCondition(Expression<Func<NuomosLaikotarpis, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(NuomosLaikotarpis entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public NuomosLaikotarpis CreateReservation(BookingDto bookingDto)
        {
            var rents = _repository.Set<NuomosLaikotarpis>().AsEnumerable();
            foreach (var rent in rents)
            {
                if (rent.Iki != null && (rent.Nuo != null && ((bookingDto.Nuo.Ticks >= ((DateTime) rent.Nuo).Ticks &&
                                                               bookingDto.Nuo.Ticks <= ((DateTime) rent.Iki).Ticks) ||
                                                              (bookingDto.Iki.Ticks >= ((DateTime) rent.Nuo).Ticks &&
                                                               bookingDto.Iki.Ticks <= ((DateTime) rent.Iki).Ticks))))
                {
                    return null;
                }
            }

            var reservation = _repository.Mapper.Map<BookingDto, NuomosLaikotarpis>(bookingDto);
            reservation.Busena = 2;
            _repository.Set<NuomosLaikotarpis>().Add(reservation);
            _repository.SaveChanges();
            return reservation;
        }

        public bool CancelReservation(BookingCancelDto cancelDto)
        {
            var rent = _repository.Set<NuomosLaikotarpis>()
                .Include(o => o.FkNuomininkasidIsNaudotojasNavigation)
                .Where(o => o.IdNuomosLaikotarpis.Equals(cancelDto.RentPeriodId) &&
                            o.FkNuomininkasidIsNaudotojas.Equals(cancelDto.TenantId));

            if (!rent.Any())
            {
                return false;
            }

            _repository.Set<NuomosLaikotarpis>().Remove(rent.First());
            _repository.SaveChanges();

            return true;
        }
    }
}