namespace Cloth.Application.Models.Dto;

public class CreateClothDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid BrandId { get; set; }
    public List<GroupDto> Groups { get; set; }
    public List<SizeDto> Sizes { get; set; }
}