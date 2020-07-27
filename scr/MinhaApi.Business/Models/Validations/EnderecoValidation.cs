using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaApi.Business.Models.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c=>c.Logradouro)
                .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
                .Length(2, 40).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
                .Length(2, 40).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo { PropertyName} precisa ser fornecido")
                .Length(2, 40).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


        }

    }
}
