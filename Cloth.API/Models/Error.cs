using System.Net;

namespace Cloth.API.Models;

public class Error
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
}
