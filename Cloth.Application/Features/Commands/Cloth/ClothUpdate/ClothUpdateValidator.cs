using FluentValidation;

namespace Cloth.Application.Features.Commands.Cloth.ClothUpdate;

public class ClothUpdateValidator: AbstractValidator<ClothUpdateCommand>
{
    public ClothUpdateValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(command => command.BrandId)
           .NotEmpty().WithMessage("BrandId is required.");

        RuleFor(command => command.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title maximum length: 50 characters.");

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description maximum length: 500 characters.");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(command => command.Groups)
            .NotEmpty().WithMessage("A Group must be provided.");

        RuleFor(command => command.Sizes)
            .NotEmpty().WithMessage("A Size must be provided.");
    }
}
