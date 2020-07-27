using MinhaApi.Business.Interfaces;
using MinhaApi.Business.Models;
using MinhaApi.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                               INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Add(cliente);
            
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Update(cliente);
        }

        public async Task Remover(int id)
        {
            await _clienteRepository.Delete(id);
        }

      

    }
}
