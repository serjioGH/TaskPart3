namespace Cloth.Application.Constants;

public static class Constants
{
    public static class ClothValidationMessages
    {
        public const string SizeMaxLength = "Size length must not be over 20 characters";

        public const string BrandIdRequired = "BrandId is required.";

        public const string TitleRequired = "Title is required.";

        public const string TitleMaxLength = "Title maximum length: 50 characters.";

        public const string DescriptionRequired = "Description is required.";

        public const string DescriptionMaxLength = "Description maximum length: 500 characters.";

        public const string PriceOverZero = "Price must be greater than 0.";

        public const string GroupRequired = "A Group must be provided.";

        public const string SizeRequired = "A Size must be provided.";
    }

    public static class BasketValidationMessages
    {
        public const string BasketLineRequired = "The basket must have BasketLines.";

        public const string PriceOverZero = "Price must be greater than 0.";

        public const string QuantityOverZero = "Quantity must be greater than 0.";

        public const string ClothIdRequired = "ClothId is required.";

        public const string BasketIdRequired = "BasketId is required.";

        public const string SizeIdRequired = "A SizeId must be provided.";
    }

    public static class OrderValidationMessages
    {
        public const string StatusRequired = "StatusId is required.";

        public const string OrderLineRequired = "The order must have OrderLines.";

        public const string ClothIdRequired = "ClothId is required.";

        public const string OrderIdRequired = "OrderId is required.";

        public const string SizeIdRequired = "A SizeId must be provided.";

        public const string TotalAmountOverZero = "Total amount must be greater than 0.";

        public const string OrderPriceOverZero = "OrderPrice must be greater than 0.";

        public const string QuantityOverZero = "Quantity must be greater than 0.";
    }

    public const string QuantityOverZero = "Quantity must be greater than 0.";

    public const string IdRequiredMessage = "Id is required.";

    public const string UserRequiredMessage = "User is required.";

    public const string MinPriceOverZero = "MinPrice must be greater than zero.";

    public const string MaxPriceOverZero = "MaxPrice must be greater than zero.";

    public const string MinPriceValidDecimal = "MinPrice must be a decimal number.";

    public const string MaxPriceValidDecimal = "MaxPrice must be a decimal number.";
}