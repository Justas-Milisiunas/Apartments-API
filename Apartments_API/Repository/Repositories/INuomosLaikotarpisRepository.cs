using Apartments_API.DTO;
using Apartments_API.Models;

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
    }
}