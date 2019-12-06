using System.Collections.Generic;
using Apartments_API.DTO;
using Apartments_API.Models;

namespace Apartments_API.Repository.Repositories
{
    public interface IJobRepository : IRepositoryBase<Darbas>
    {
        /// <summary>
        /// Adds to job Worker id and changes job status to "taken"
        /// <summary>
        /// <param name="entity"> Jobs data to be replaced</param>
        /// <returns>changed Job data</returns>
        IEnumerable<Darbas> MakeJobAsTaken(JobAcceptDto entity);

        /// <summary>
        /// Adds to job Worker id and changes job status to "taken"
        /// <summary>
        /// <param name="entity"> Jobs data to be replaced</param>
        /// <returns>changed Job data</returns>
        IEnumerable<Darbas> MakeJobAsDone(JobAcceptDto entity);

        IEnumerable<Darbas> CancelJob(JobAcceptDto entity);

        IEnumerable<Darbas> FindHistory(int id);

        IEnumerable<Darbas> FindDataToReport(int id);

    }
}