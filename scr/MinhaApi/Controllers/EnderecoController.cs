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
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : MainController
    {

        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEnderecoService _enderecoService;
       
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoRepository enderecoRepository,
                                      IMapper mapper,
                                      IEnderecoService enderecoService,
                                      INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _enderecoService = enderecoService;
        }

        [HttpGet]
        /// <summary>
        /// Busca todos os Endereços disponíveis
        /// </summary>
        public async Task<IEnumerable<EnderecoViewModel>> ObterTodos()
       {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        /// <summary>
        /// Busca um Endereço pelo seu ID
        /// </summary>
        public async Task<ActionResult<EnderecoViewModel>> ObterPorId(int id)
        {
            var endereco = await _enderecoRepository.Get(id);

            if (endereco == null) return NotFound();

            return _mapper.Map<EnderecoViewModel>(endereco);
        }

        [HttpPost]
        /// <summary>
        /// Adiciona um Endereço
        /// </summary>
        public async Task<ActionResult<EnderecoViewModel>> Adicionar(EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _enderecoService.Adicionar(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        [HttpPut("{id:int}")]
        /// <summary>
        /// Atualiza um endereço
        /// </summary>
        public async Task<ActionResult<EnderecoViewModel>> Atualizar(int id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _enderecoService.Atualizar(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        [HttpDelete("{id:int}")]
        /// <summary>
        /// Exclui um Endereço
        /// </summary>
        public async Task<ActionResult<EnderecoViewModel>> Excluir(int id)
        {
            var fornecedorViewModel = await _enderecoRepository.Get(id);

            if (fornecedorViewModel == null) return NotFound();

            await _enderecoService.Remover(id);

            return CustomResponse(fornecedorViewModel);
        }

    }
}