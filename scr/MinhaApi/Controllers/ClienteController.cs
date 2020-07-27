using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Api.ViewModels;
using MinhaApi.Business.Interfaces;
using MinhaApi.Business.Models;

namespace MinhaApi.Api.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : MainController
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
       
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
                                      IMapper mapper,
                                      IClienteService clienteService,
                                      INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpGet]
        /// <summary>
        /// Busca todos os Clientes disponíveis
        /// </summary>
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
       {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        /// <summary>
        /// Busca um Cliente pelo seu ID
        /// </summary>
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(int id)
        {
            var cliente = await _clienteRepository.Get(id);

            if (cliente == null) return NotFound();

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        [HttpPost]
        /// <summary>
        /// Adiciona um Cliente
        /// </summary>
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpPut("{id:int}")]
        /// <summary>
        /// Atualiza um Cliente
        /// </summary>
        public async Task<ActionResult<ClienteViewModel>> Atualizar(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(clienteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpDelete("{id:int}")]
        /// <summary>
        /// Exclui um Cliente
        /// </summary>
        public async Task<ActionResult<ClienteViewModel>> Excluir(int id)
        {
            var clienteViewModel = await _clienteRepository.Get(id);

            if (clienteViewModel == null) return NotFound();

            await _clienteService.Remover(id);

            return CustomResponse(clienteViewModel);
        }

    }
}