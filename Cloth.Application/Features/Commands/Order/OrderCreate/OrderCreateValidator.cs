using FluentValidation;
namespace Cloth.Application.Features.Commands.Order.OrderCreate;

public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("StatusId is required.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.OrderDate).NotEmpty().WithMessage("OrderDate is required.");
        RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("TotalAmount must not be 0.");
        RuleForEach(x => x.OrderLines).SetValidator(new OrderLineCreateValidator());
    }
}
