namespace Cloth.Application.Features.Queries.GetCloths;

using Cloth.Application.Constants;
using FluentValidation;

public class GetClothQueryValidator : AbstractValidator<ClothQuery>
{
    public GetClothQueryValidator()
    {
        RuleFor(c => c.MinPrice)
            .Empty()
                .When(c => c.MinPrice.HasValue && c.MinPrice <= 0)
                .WithMessage(ClothValidationErrorMessages.MinPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MinPrice.HasValue)
                .WithMessage(ClothValidationErrorMessages.MinPriceValidDecimal);

        RuleFor(c => c.MaxPrice)
            .Empty()
                .When(c => c.MaxPrice.HasValue && c.MaxPrice <= 0)
                .WithMessage(ClothValidationErrorMessages.MaxPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MaxPrice.HasValue)
                .WithMessage(ClothValidationErrorMessages.MaxPriceValidDecimal);

        RuleFor(c => c.Size)
            .MaximumLength(20)
                .When(c => !string.IsNullOrEmpty(c.Size))
                .WithMessage(ClothValidationErrorMessages.SizeMaxLength);
    }

    private bool IsValidDecimal(decimal? value)
    {
        return value == null || decimal.TryParse(value.ToString(), out _);
    }
}

