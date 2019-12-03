using System.Collections.Generic;
using Apartments_API.DTO;
using Apartments_API.Models;

namespace Apartments_API.Repository.Repositories
{
    public interface IIsNaudotojasRepository : IRepositoryBase<IsNaudotojas>
    {
        /// <summary>
        /// Saves user in the database table IsNaudotojas
        /// </summary>
        /// <param name="entity">New user's data</param>
        /// <returns>Saved user data</returns>
        IsNaudotojas Create(UserCreateDto entity);
    }
}