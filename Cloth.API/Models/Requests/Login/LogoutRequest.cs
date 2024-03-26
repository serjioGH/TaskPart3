namespace Cloth.API.Models.Requests.Login;

public class LogoutRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}