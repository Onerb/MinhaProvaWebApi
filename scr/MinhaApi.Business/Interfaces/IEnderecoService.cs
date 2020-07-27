using MinhaApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Business.Interfaces
{
    public interface IEnderecoService 
    {
        Task Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task Remover(int id);
    }
}
