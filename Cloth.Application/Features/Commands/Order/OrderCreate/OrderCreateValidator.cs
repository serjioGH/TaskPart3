namespace Cloth.Application.Features.Commands.Order.OrderCreate;

using FluentValidation;
using Constants;

public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage(Constants.OrderValidationMessages.StatusRequired);
        RuleFor(x => x.UserId).NotEmpty().WithMessage(Constants.UserRequiredMessage);
        RuleForEach(x => x.OrderLines).SetValidator(new OrderLineCreateValidator());
    }
}