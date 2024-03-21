namespace Cloth.Application.Features.Commands.Cloths.ClothCreate;

using FluentValidation;
using Cloth.Application.Models.Dto;
using Constants;

public class SizeClothDtoValidator : AbstractValidator<SizeClothDto>
{
    public SizeClothDtoValidator()
    {
        RuleFor(command => command.QuantityInStock)
            .GreaterThan(0).WithMessage(Constants.QuantityOverZero);
    }
}