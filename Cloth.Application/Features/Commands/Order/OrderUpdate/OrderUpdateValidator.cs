namespace Cloth.Application.Features.Commands.Order.OrderUpdate;

using Constants;
using FluentValidation;

public class OrderUpdateValidator : AbstractValidator<OrderUpdateCommand>
{
    public OrderUpdateValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage(Constants.OrderValidationMessages.OrderIdRequired);
        RuleFor(command => command.UserId).NotEmpty().WithMessage(Constants.UserRequiredMessage);
        RuleFor(command => command.StatusId).NotEmpty().WithMessage(Constants.OrderValidationMessages.StatusRequired);
        RuleFor(command => command.OrderLines).NotEmpty().WithMessage(Constants.OrderValidationMessages.OrderLineRequired);
    }
}