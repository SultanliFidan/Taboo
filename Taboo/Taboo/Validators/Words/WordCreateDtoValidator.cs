using FluentValidation;
using Taboo.DTOs.Words;
using Taboo.Enums;

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
                .NotNull()
                .Must(x => x.Count() == (int)GameLevel.Hard)
                .WithMessage((int)GameLevel.Hard + "eded unikal qadagan olunmus soz yazmalisiniz");
            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MaximumLength(32);

        }
    }
}
