namespace Cloth.Application.Features.Commands.Basket.BasketLineDeleteAll;

using FluentValidation;

public class BasketLineDeleteAllValidator : AbstractValidator<BasketLineDeleteAllCommand>
{
    public BasketLineDeleteAllValidator()
    {
        RuleFor(command => command.UserId).NotEmpty();
    }
}