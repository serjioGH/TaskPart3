namespace Cloth.API.Models.Responses.Login;

public class LoginResponse
{
    public string Username { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}