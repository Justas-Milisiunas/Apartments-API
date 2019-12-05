using Apartments_API.Repository.Repositories;

namespace Apartments_API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;

        private IIsNaudotojasRepository _isNaudotojas;
        private IButasRepository _butas;
        private INuomosLaikotarpisRepository _nuomosLaikotarpis;
        private IComplaintRepository _skundas;


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

        public INuomosLaikotarpisRepository NuomosLaikotarpis
        {
            get { return _nuomosLaikotarpis ??= new NuomosLaikotarpisRepository(_repositoryContext); }
        }

        public IComplaintRepository Skundas
        {
            get { return _skundas ??= new ComplaintRepository(_repositoryContext); }
        }


        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}