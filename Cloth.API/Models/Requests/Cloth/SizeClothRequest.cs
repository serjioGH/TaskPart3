namespace Cloth.API.Models.Requests;

public class SizeClothRequest
{
    public Guid SizeId { get; set; }

    public int QuantityInStock { get; set; }
}