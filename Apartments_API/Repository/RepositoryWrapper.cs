using Apartments_API.Repository.ModelsRepositories;

namespace Apartments_API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IButasRepository _butas;
        private IIsNaudotojasRepository _isNaudotojas;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IButasRepository Butas
        {
            get { return _butas ??= new ButasRepository(_repositoryContext); }
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