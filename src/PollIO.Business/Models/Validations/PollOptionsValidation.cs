using FluentValidation;

namespace PollIO.Business.Models.Validations
{
    public class PollOptionsValidation : AbstractValidator<OptionsPoll>
    {
        public PollOptionsValidation()
        {
            RuleFor(p => p.PollId.ToString())
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
