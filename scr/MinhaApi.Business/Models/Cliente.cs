using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaApi.Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdEndereco { get; set; }
        //public Endereco Endereco { get; set; }
    }
}
