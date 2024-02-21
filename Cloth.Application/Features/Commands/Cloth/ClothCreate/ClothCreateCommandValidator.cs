namespace Cloth.Application.Features.Commands.Cloths.ClothCreate;

using Cloth.Application.Constants;
using FluentValidation;

public class ClothCreateCommandValidator : AbstractValidator<ClothCreateCommand>
{
    public ClothCreateCommandValidator()
    {
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

        RuleForEach(command => command.Sizes)
            .SetValidator(new SizeClothDtoValidator());
    }
}