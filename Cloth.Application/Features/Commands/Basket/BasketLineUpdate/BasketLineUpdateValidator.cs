namespace Cloth.Application.Features.Commands.Basket.BasketLineUpdate;

using FluentValidation;
using Constants;

public class BasketLineUpdateValidator : AbstractValidator<BasketLineUpdateCommand>
{
    public BasketLineUpdateValidator()
    {
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0).WithMessage(Constants.BasketValidationMessages.QuantityOverZero);
        RuleFor(dto => dto.SizeId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.SizeIdRequired);
        RuleFor(dto => dto.BasketLineId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.BasketIdRequired);
        RuleFor(dto => dto.ClothId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.ClothIdRequired);
    }
}