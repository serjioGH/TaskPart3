namespace Cloth.API.Models.Requests.Cloth;

public class ClothUpdateRequest
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public List<GroupClothRequest> Groups { get; set; }

    public List<SizeClothRequest> Sizes { get; set; }
}