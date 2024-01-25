namespace Cloth.Application.Constants;

public static class ClothValidationErrorMessages
{
    public const string MinPriceOverZero = "MinPrice must be greater than zero.";
    public const string MaxPriceOverZero = "MaxPrice must be greater than zero.";
    public const string MinPriceValidDecimal = "MinPrice must be a decimal number.";
    public const string MaxPriceValidDecimal = "MaxPrice must be a decimal number.";
    public const string SizeMaxLength = "Size length must not be over 20 characters";
}

