using MinhaApi.Business.Interfaces;
using MinhaApi.Business.Models;
using MinhaApi.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository,
                               INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Add(endereco);
            
        }

        public async Task Atualizar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Update(endereco);
        }

        public async Task Remover(int id)
        {
            await _enderecoRepository.Delete(id);
        }

      

    }
}
