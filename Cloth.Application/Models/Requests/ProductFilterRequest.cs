namespace Cloth.Application.Models.Requests;

public class ProductFilterRequest
{
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public string? Size { get; set; }
    public string? Highlight { get; set; }
}
