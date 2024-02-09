using Cloth.Application.Models.Dto;
using FluentValidation;

namespace Cloth.Application.Features.Commands.Order.OrderCreate;

public class OrderLineCreateValidator : AbstractValidator<OrderLineDto>
{
    public OrderLineCreateValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required.");
        RuleFor(x => x.ClothId).NotEmpty().WithMessage("ClothId is required.");
        RuleFor(x => x.SizeId).NotEmpty().WithMessage("SizeId is required.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
