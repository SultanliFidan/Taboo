using FluentValidation;
using Taboo.DTOs.Words;

namespace Taboo.Validators.Words
{
    public class WordCreateDtoValidator :AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
            RuleFor(x => x.BannedWords)
                .NotNull();
            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MaximumLength(32);

        }
    }
}
