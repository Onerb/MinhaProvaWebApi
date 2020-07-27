using MinhaApi.Business.Interfaces;

namespace MinhaApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        public UnitOfWork(IClienteRepository enderecoRepository)
        {
            Endereco = enderecoRepository;
        }

        public IClienteRepository Endereco { get; }
    }
}
