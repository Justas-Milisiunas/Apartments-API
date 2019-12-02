using Apartments_API.Repository.Repositories;

namespace Apartments_API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;

        private IIsNaudotojasRepository _isNaudotojas;
        public IButasRepository _butas;
        public IJobRepository _job;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IIsNaudotojasRepository IsNaudotojas
        {
            get { return _isNaudotojas ??= new IsNaudotojasRepository(_repositoryContext); }
        }

        public IButasRepository Butas
        {
            get { return _butas ??= new ButasRepository(_repositoryContext); }
        }

        public IJobRepository Job
        {
            get { return _job ??= new JobRepository(_repositoryContext);}
        }


        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}