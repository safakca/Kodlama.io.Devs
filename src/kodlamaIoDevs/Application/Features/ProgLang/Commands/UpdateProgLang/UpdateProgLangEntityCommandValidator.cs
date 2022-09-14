using FluentValidation;

namespace Application.Features.ProgLang.Commands.UpdateProgLang;
public class UpdateProgLangEntityCommandValidator : AbstractValidator<UpdateProgLangEntityCommand>
{
    public UpdateProgLangEntityCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}

