using Apartments_API.Repository.Repositories;

namespace Apartments_API.Repository
{
    /// <summary>
    /// All repositories wrapper for easier dependency injection
    /// </summary>
    public interface IRepositoryWrapper
    {
        IIsNaudotojasRepository IsNaudotojas { get; }
        IButasRepository Butas { get; }
        INuomosLaikotarpisRepository NuomosLaikotarpis { get; }
        IComplaintRepository Skundas { get; }

        IJobRepository Job { get; }

        void Save();
    }
}