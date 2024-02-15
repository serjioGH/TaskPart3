using Cloth.Application.Models.Dto;
using FluentValidation;

namespace Cloth.Application.Features.Commands.Order.OrderCreate;

using Constants;

public class OrderLineCreateValidator : AbstractValidator<OrderLineDto>
{
    public OrderLineCreateValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage(Constants.OrderValidationMessages.OrderIdRequired);
        RuleFor(x => x.ClothId).NotEmpty().WithMessage(Constants.OrderValidationMessages.ClothIdRequired);
        RuleFor(x => x.SizeId).NotEmpty().WithMessage(Constants.OrderValidationMessages.SizeIdRequired);
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(Constants.OrderValidationMessages.QuantityOverZero);
        RuleFor(x => x.Price).GreaterThan(0).WithMessage(Constants.OrderValidationMessages.OrderPriceOverZero);
    }
}