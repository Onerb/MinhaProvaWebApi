using MinhaApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Business.Interfaces
{
    public interface IClienteService 
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(int id);
    }
}
