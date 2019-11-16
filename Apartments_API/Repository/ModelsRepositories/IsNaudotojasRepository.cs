using Apartments_API.Models;

namespace Apartments_API.Repository.ModelsRepositories
{
    public class IsNaudotojasRepository : RepositoryBase<IsNaudotojas>, IIsNaudotojasRepository
    {
        public IsNaudotojasRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}