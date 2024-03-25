namespace Cloth.Persistence.PostgreSQL.Constants.DapperQueries;

public static class ReadFromDbConstants
{
    public static class ClothConstants
    {
        public static string GetAllClothsQuery = """
            SELECT p.*, b.*, cg.*, cs.*, s.*, g.*
            FROM "Cloths" p
            LEFT JOIN "Brands" b ON p."BrandId" = b."Id"
            LEFT JOIN "ClothGroups" cg ON p."Id" = cg."ClothId"
            LEFT JOIN "ClothSizes" cs ON p."Id" = cs."ClothId"
            LEFT JOIN "Sizes" s ON cs."SizeId" = s."Id"
            LEFT JOIN "Groups" g ON cg."GroupId" = g."Id"
            WHERE p."IsDeleted" = FALSE
            """;

        public static string GetClothQuery = """
            SELECT p.*, b.*, cg.*, g.*, cs.*, s.*
            FROM "Cloths" p
            LEFT JOIN "Brands" b ON p."BrandId" = b."Id"
            LEFT JOIN "ClothGroups" cg ON p."Id" = cg."ClothId"
            LEFT JOIN "Groups" g ON cg."GroupId" = g."Id"
            LEFT JOIN "ClothSizes" cs ON p."Id" = cs."ClothId"
            LEFT JOIN "Sizes" s ON cs."SizeId" = s."Id"
            WHERE p."Id" = @Id AND p."IsDeleted" = FALSE
            """;

        public static string GetClothGroups = """
            SELECT cg.*, g.*
            FROM "ClothGroups" cg
            INNER JOIN "Groups" g ON cg."GroupId" = g."Id"
            WHERE cg."ClothId" = @ClothId
            """;

        public static string GetClothSizes = """
            SELECT cs.*, s.*
            FROM "ClothSizes" cs
            INNER JOIN "Sizes" s ON cs."SizeId" = s."Id"
            WHERE cs."ClothId" = @ClothId
            """;
    }

    public static class BasketConstants
    {
        public const string GetBasketByUserIdQuery = """
             SELECT b.*, u.*, bl.*, c.*, s.*
             FROM "Baskets" b
             LEFT JOIN "Users" u ON b."UserId" = u."Id"
             LEFT JOIN "BasketLines" bl ON b."Id" = bl."BasketId"
             LEFT JOIN "Cloths" c ON bl."ClothId" = c."Id"
             LEFT JOIN "Sizes" s ON bl."SizeId" = s."Id"
             WHERE b."UserId" = @UserId
             """;
    }

    public static class ClothSizeConstants
    {
        public const string GetByCompositeKeyQuery = """
            SELECT *
            FROM "ClothSizes"
            WHERE "ClothId" = @ClothId AND "SizeId" = @SizeId
            """;
    }

    public static class OrderConstants
    {
        public static string GetOrderDetailsQuery = """
             SELECT o.*, u.*, s.*,ol.*
             FROM "Orders" o
             INNER JOIN "Users" u ON o."UserId" = u."Id"
             INNER JOIN "OrderStatus" s ON o."StatusId" = s."Id"
             INNER JOIN "OrderLines" ol ON o."Id" = ol."OrderId"
             WHERE o."IsDeleted" = false
             """;

        public static string GetOrderByIdQuery = """
             SELECT o.*, u.*, s.*,ol.*
             FROM "Orders" o
             INNER JOIN "Users" u ON o."UserId" = u."Id"
             INNER JOIN "OrderStatus" s ON o."StatusId" = s."Id"
             INNER JOIN "OrderLines" ol ON o."Id" = ol."OrderId"
             WHERE o."Id" = @OrderId
             AND o."IsDeleted" = false
             """;
    }

    public static class UserConstants
    {
        public static string GetUserByPassAndUsername = """
             SELECT u.*
             FROM "Users" u
             WHERE u."Password" = @Password
             AND u."Username" = @Username
             AND u."IsDeactivated" = false
             """;
    }
}