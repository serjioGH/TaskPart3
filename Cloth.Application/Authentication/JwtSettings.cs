namespace Cloth.Application.Authentication;

public class JwtSettings
{
    public const string SectionName = "Jwt";
    public string? Key { get; init; }
    public string? Issuer { get; init; }
    public string? Audience { get; init; }
    public int ExpiresInMinutes { get; init; }
}