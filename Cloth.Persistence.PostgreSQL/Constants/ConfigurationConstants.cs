namespace Cloth.Persistence.PostgreSQL.Constants;

public static class ConfigurationConstants
{
    public const string DecimalType = "decimal(18, 2)";

    public const string DecimalTypeNpgsql = "numeric(18, 2)";

    public const string NvarcharType = "nvarchar(max)";

    public const string VarcharType = "varchar";

    public const string DateColumnTypeNpgsql = "date";

    public const string GetdateType = "getDate()";

    public const string GetdateTypeNpgsql = "CURRENT_DATE";

    public const string BitType = "bit";
}