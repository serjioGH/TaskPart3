namespace Cloth.API.Models.Requests.Login;

public class RefreshTokenRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}