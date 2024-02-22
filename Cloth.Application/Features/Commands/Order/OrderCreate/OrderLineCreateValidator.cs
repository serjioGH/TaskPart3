using Cloth.Application.Models.Dto;
using FluentValidation;

namespace Cloth.Application.Features.Commands.Order.OrderCreate;

using Constants;

public class OrderLineCreateValidator : AbstractValidator<OrderLineCreateDto>
{
    public OrderLineCreateValidator()
    {
        RuleFor(x => x.ClothId).NotEmpty().WithMessage(Constants.OrderValidationMessages.ClothIdRequired);
        RuleFor(x => x.SizeId).NotEmpty().WithMessage(Constants.OrderValidationMessages.SizeIdRequired);
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(Constants.OrderValidationMessages.QuantityOverZero);
    }
}