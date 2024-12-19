using FluentValidation;
using Taboo.DTOs.Languages;

namespace Taboo.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code bos ola bilmez")
                .MaximumLength(2)
                .WithMessage("Code uzunlugu 2-den cox ola bilmez");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name bos ola bilmez")
                .MaximumLength(64)
                .WithMessage("Name uzunlugu 64-den cox ola bilmez");
            RuleFor(x => x.IconUrl)
                .NotNull()
                .NotEmpty()
                .WithMessage("Icon bos ola bilmez")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Icon deyeri link olmalidir")
                .MaximumLength(128)
                .WithMessage("Icon uzunlugu 128-den cox ola bilmez");
        }
    }
}
