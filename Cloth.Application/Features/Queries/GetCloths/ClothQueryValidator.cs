namespace Cloth.Application.Features.Queries.GetCloths;

using Cloth.Application.Models.Messages;
using FluentValidation;

public class ClothQueryValidator : AbstractValidator<ClothQuery>
{
    public ClothQueryValidator()
    {
        RuleFor(c => c.MinPrice)
            .Empty()
                .When(c => c.MinPrice.HasValue && c.MinPrice <= 0)
                .WithMessage(ClothErrorMessages.MinPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MinPrice.HasValue)
                .WithMessage(ClothErrorMessages.MinPriceValidDecimal);

        RuleFor(c => c.MaxPrice)
            .Empty()
                .When(c => c.MaxPrice.HasValue && c.MaxPrice <= 0)
                .WithMessage(ClothErrorMessages.MaxPriceOverZero)
            .Must(IsValidDecimal)
                .When(c => c.MaxPrice.HasValue)
                .WithMessage(ClothErrorMessages.MaxPriceValidDecimal);

        RuleFor(c => c.Size)
            .MaximumLength(20)
                .When(c => !string.IsNullOrEmpty(c.Size))
                .WithMessage(ClothErrorMessages.SizeMaxLength);
    }

    private bool IsValidDecimal(decimal? value)
    {
        return value == null || decimal.TryParse(value.ToString(), out _);
    }
}

