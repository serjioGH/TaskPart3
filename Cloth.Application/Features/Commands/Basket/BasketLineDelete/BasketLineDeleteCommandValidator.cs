namespace Cloth.Application.Features.Commands.Basket.BasketLineDelete;

using FluentValidation;

public class BasketLineDeleteCommandValidator : AbstractValidator<BasketLineDeleteCommand>
{
    public BasketLineDeleteCommandValidator()
    {
        RuleFor(command => command.basketLineId).NotEmpty();
    }
}