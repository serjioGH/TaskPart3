namespace Cloth.Application.Models.Dto;

public class UpdateOrderDto
{
    public Guid Id { get; set; }
    public Guid StatusId { get; set; }
    public Guid PaymentId { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public string? Status { get; set; }

    public string? FullName { get; set; }
    public decimal TotalAmount { get; set; }
}