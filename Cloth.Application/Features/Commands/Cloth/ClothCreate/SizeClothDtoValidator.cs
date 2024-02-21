namespace Cloth.Application.Features.Commands.Cloths.ClothCreate;

using FluentValidation;
using global::Cloth.Application.Models.Dto;
using Constants;

public class SizeClothDtoValidator : AbstractValidator<SizeClothDto>
{
    public SizeClothDtoValidator()
    {
        RuleFor(command => command.Quantity)
            .GreaterThan(0).WithMessage(Constants.QuantityOverZero);
    }
}