using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApi.Api.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]

        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public int Idade { get { return (DateTime.Now.Year - DataNascimento.Year); } }
      
        public int IdEndereco { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
