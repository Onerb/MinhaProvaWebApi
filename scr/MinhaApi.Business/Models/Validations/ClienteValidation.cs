using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using static MinhaApi.Business.Models.Validations.Documentos.ValidaDocumento;

namespace MinhaApi.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                   .WithMessage("O campo Cpf precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CpfValidacao.Validar(f.Cpf)).Equal(true)
                .WithMessage("O Cpf fornecido é inválido.");

            //RuleFor(c => c.DataNascimento)
            //    .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
            //    .Length(2, 40).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
                .Length(2, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

         
        }

    }
}
