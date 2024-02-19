namespace Cloth.Application.Models.Dto;

using Domain.Enumarations;

public class OrderDto
{
    public Guid Id { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime OrderDate { get; set; }

    public string FullName { get; set; }

    public decimal TotalAmount { get; set; }
}