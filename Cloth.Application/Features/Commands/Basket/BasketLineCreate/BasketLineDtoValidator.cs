namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using FluentValidation;
using Constants;
using Cloth.Application.Models.Dto.Basket;

public class BasketLineDtoValidator : AbstractValidator<BasketLineDto>
{
    public BasketLineDtoValidator()
    {
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0).WithMessage(Constants.BasketValidationMessages.QuantityOverZero);
        RuleFor(dto => dto.BasketId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.BasketIdRequired);
        RuleFor(dto => dto.ClothId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.ClothIdRequired);
        RuleFor(dto => dto.SizeId)
            .NotEmpty().WithMessage(Constants.BasketValidationMessages.SizeIdRequired);
    }
}