using Apartments_API.DTO;
using Apartments_API.Models;
using System.Collections.Generic;

namespace Apartments_API.Repository.Repositories
{
    public interface INuomosLaikotarpisRepository : IRepositoryBase<NuomosLaikotarpis>
    {
        /// <summary>
        /// Makes reservation for the selected apartment
        /// </summary>
        /// <param name="bookingDto">Booking information</param>
        /// <returns>Booking information with id</returns>
        NuomosLaikotarpis CreateReservation(BookingDto bookingDto);

        /// <summary>
        /// Removes nuomos laikotarpis object from the db
        /// </summary>
        /// <param name="cancelDto">Cancel data</param>
        /// <returns>true if removed successfully, false if not</returns>
        bool CancelReservation(BookingCancelDto cancelDto);
        IEnumerable<NuomosLaikotarpis> Search(ReportDto searchDto, int idButas);
        public bool DeleteApart(int idButas);

    }
}