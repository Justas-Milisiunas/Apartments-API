
using Apartments_API.Repository.Repositories;

namespace Apartments_API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;

        private IIsNaudotojasRepository _isNaudotojas;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        
        public IIsNaudotojasRepository IsNaudotojas
        {
            get { return _isNaudotojas ??= new IsNaudotojasRepository(_repositoryContext); }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}