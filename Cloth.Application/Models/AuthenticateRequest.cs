namespace Cloth.Application.Models;

using System.ComponentModel;

public class AuthenticateRequest
{
    [DefaultValue("Serj")]
    public string Username { get; set; }

    [DefaultValue("password")]
    public string Password { get; set; }
}