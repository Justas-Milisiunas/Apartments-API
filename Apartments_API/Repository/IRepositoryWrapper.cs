using Apartments_API.Repository.ModelsRepositories;

namespace Apartments_API.Repository
{
    public interface IRepositoryWrapper
    {
        IButasRepository Butas { get; }
        IIsNaudotojasRepository IsNaudotojas { get; }

        void Save();
    }
}