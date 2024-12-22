using FluentValidation;
using Taboo.DTOs.BannedWords;

namespace Taboo.Validators.BannedWords
{
    public class BannedWordUpdateDtoValidator : AbstractValidator<BannedWordUpdateDto>
    {
        public BannedWordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
