using FluentValidation;
using Taboo.DTOs.BannedWords;

namespace Taboo.Validators.BannedWords
{
    public class BannedWordCreateDtoValidator : AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
