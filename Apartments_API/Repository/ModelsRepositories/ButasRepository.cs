using Apartments_API.Models;

namespace Apartments_API.Repository.ModelsRepositories
{
    public class ButasRepository : RepositoryBase<Butas>, IButasRepository
    {
        public ButasRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}