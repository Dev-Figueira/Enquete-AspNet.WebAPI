using FluentValidation;

namespace PollIO.Business.Models.Validations
{
    public class PollValidation : AbstractValidator<Poll>
    {
        public PollValidation()
        {
            RuleFor(p => p.Poll_description)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
