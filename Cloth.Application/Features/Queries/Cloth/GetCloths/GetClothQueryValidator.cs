namespace Cloth.Application.Features.Queries.Cloths.GetCloths;

using Cloth.Application.Constants;
using FluentValidation;

public class GetClothQueryValidator : AbstractValidator<ClothQuery>
{
    public GetClothQueryValidator()
    {
        RuleFor(c => c.MinPrice)
            .Empty()
                .When(c => c.MinPrice.HasValue && c.MinPrice <= 0)
                .WithMessage(Constants.MinPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MinPrice.HasValue)
                .WithMessage(Constants.MinPriceValidDecimal);

        RuleFor(c => c.MaxPrice)
            .Empty()
                .When(c => c.MaxPrice.HasValue && c.MaxPrice <= 0)
                .WithMessage(Constants.MaxPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MaxPrice.HasValue)
                .WithMessage(Constants.MaxPriceValidDecimal);

        RuleFor(c => c.Size)
            .MaximumLength(20)
                .When(c => !string.IsNullOrEmpty(c.Size))
                .WithMessage(Constants.ClothValidationMessages.SizeMaxLength);
    }

    private bool IsValidDecimal(decimal? value)
    {
        return value == null || decimal.TryParse(value.ToString(), out _);
    }
}