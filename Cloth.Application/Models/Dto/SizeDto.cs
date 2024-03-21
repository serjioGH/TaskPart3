namespace Cloth.Application.Models.Dto;

using Domain.Enumarations;

public class SizeDto
{
    public Guid SizeId { get; set; }

    public string Size { get; set; }

    public int QuantityInStock { get; set; }
}