namespace Cloth.Persistence.PostgreSQL.Constants.DapperQueries;

public static class CommandConstants
{
    public static class ClothConstants
    {
        public const string InsertClothQuery = """
             INSERT INTO "Cloths" ("Id", "BrandId", "Title", "Description", "Price", "IsDeleted")
             VALUES (@Id, @BrandId, @Title, @Description, @Price, @IsDeleted)
             """;

        public static string InsertClothGroup = """
            INSERT INTO "ClothGroups" ("ClothId", "GroupId")
            VALUES (@ClothId, @GroupId)
            """;

        public static string InsertClothSize = """
            INSERT INTO "ClothSizes" ("ClothId", "SizeId", "QuantityInStock")
            VALUES (@ClothId, @SizeId, @QuantityInStock)
            """;

        public static string UpdateCloth = """
            UPDATE "Cloths"
            SET
                "BrandId" = @BrandId,
                "Title" = @Title,
                "Price" = @Price,
                "Description" = @Description,
                "IsDeleted" = @IsDeleted
            WHERE
                "Id" = @Id
            """;

        public static string DeleteClothGroups = """
            DELETE FROM "ClothGroups"
            WHERE "ClothId" = @ClothId
            """;

        public static string DeleteClothSizes = """
            DELETE FROM "ClothSizes"
            WHERE "ClothId" = @ClothId
            """;

        public const string DeletedClothSet = """
            UPDATE "Cloths" SET "IsDeleted" = @IsDeleted
            WHERE "Id" = @Id
            """;
    }
}