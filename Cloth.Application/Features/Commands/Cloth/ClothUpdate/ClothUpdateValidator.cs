namespace Cloth.Application.Features.Commands.Cloth.ClothUpdate;

using FluentValidation;
using Constants;

public class ClothUpdateValidator : AbstractValidator<ClothUpdateCommand>
{
    public ClothUpdateValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage(Constants.IdRequiredMessage);

        RuleFor(command => command.BrandId)
           .NotEmpty().WithMessage(Constants.ClothValidationMessages.BrandIdRequired);

        RuleFor(command => command.Title)
            .NotEmpty().WithMessage(Constants.ClothValidationMessages.TitleRequired)
            .MaximumLength(50).WithMessage(Constants.ClothValidationMessages.TitleMaxLength);

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage(Constants.ClothValidationMessages.DescriptionRequired)
            .MaximumLength(500).WithMessage(Constants.ClothValidationMessages.DescriptionMaxLength);

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage(Constants.ClothValidationMessages.PriceOverZero);

        RuleFor(command => command.Groups)
            .NotEmpty().WithMessage(Constants.ClothValidationMessages.GroupRequired);

        RuleFor(command => command.Sizes)
            .NotEmpty().WithMessage(Constants.ClothValidationMessages.SizeRequired);
    }
}