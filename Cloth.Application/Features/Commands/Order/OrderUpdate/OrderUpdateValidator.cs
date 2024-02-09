using FluentValidation;

namespace Cloth.Application.Features.Commands.Order.OrderUpdate;

public class OrderUpdateValidator : AbstractValidator<OrderUpdateCommand>
{
    public OrderUpdateValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Order Id is required.");
        RuleFor(command => command.UserId).NotEmpty().WithMessage("User Id is required.");
        RuleFor(command => command.StatusId).NotEmpty().WithMessage("Status Id is required.");
        RuleFor(command => command.OrderLines).NotEmpty().WithMessage("OrderLines must not be empty.");
    }
}
