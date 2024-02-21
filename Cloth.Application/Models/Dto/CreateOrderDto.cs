namespace Cloth.Application.Models.Dto;

using Cloth.Domain.Enumarations;

public class CreateOrderDto
{
    public Guid Id { get; set; }
    public OrderStatus? Status { get; set; }
    public string FullName { get; set; }
    public decimal TotalAmount { get; set; }
}