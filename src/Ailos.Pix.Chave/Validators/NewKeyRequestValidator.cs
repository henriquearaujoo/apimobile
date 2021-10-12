using Ailos.Pix.Chave.DTO.Request;
using FluentValidation;

namespace Ailos.Pix.Chave.Validators
{
    public class NewKeyRequestValidator : AbstractValidator<NewKeyRequest>
    {
        public NewKeyRequestValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Request não pode ser nulo");

            RuleFor(x => x.CodeType)
                .GreaterThan(0)
                .WithMessage("CodeType não pode ser menor que 1");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Descrição não pode estar vazia");

            RuleFor(x => x.SessionID)
                .NotEmpty()
                .WithMessage("SessionID não pode estar vazia")
                .MinimumLength(1)
                .WithMessage("SessionID precisa ter pelo menos um caracter");
        }
    }
}
