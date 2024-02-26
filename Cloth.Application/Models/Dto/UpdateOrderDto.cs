namespace Cloth.Application.Models.Dto;

using Domain.Enumarations;

public class UpdateOrderDto
{
    public Guid Id { get; set; }

    public Guid? StatusId { get; set; }

    public string? FullName { get; set; }
}