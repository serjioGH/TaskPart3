namespace Cloth.Persistence.Abstractions.Constants;

public static class QueryConstants
{
    public static string SelectEntity(string entity) => $"""SELECT * FROM "{entity}s" """;

    public static string SelectEntityById(string entity) => $"""SELECT * FROM "{entity}s" WHERE "Id" = @id""";
}