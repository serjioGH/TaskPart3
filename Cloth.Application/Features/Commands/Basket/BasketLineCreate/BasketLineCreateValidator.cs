namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using Constants;
using FluentValidation;

public class BasketLineCreateValidator : AbstractValidator<BasketLineCreateCommand>
{
    public BasketLineCreateValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage(Constants.UserRequiredMessage);
        RuleFor(command => command.BasketLine)
            .NotNull().WithMessage(Constants.BasketValidationMessages.BasketLineRequired)
            .SetValidator(new BasketLineDtoValidator()!);
    }
}