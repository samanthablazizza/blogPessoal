using blogpessoal.Model;
using FluentValidation;

namespace blogpessoal.Validator
{
    public class PostagemValidator : AbstractValidator<Postagem>
    {
        public PostagemValidator() //Regras de validação: validar as informações que nossa aplicação irá receber e impedir que execute caso uma das regras forem atendidas
        {
            RuleFor(p => p.Titulo)
                    .NotEmpty()
                    .MinimumLength(5) //mínimo de caracteres
                    .MaximumLength(100); //máximo de caracteres

            RuleFor(p => p.Texto)
                    .NotEmpty()
                    .MinimumLength(10)
                    .MaximumLength(1000);
        }
    }
}
