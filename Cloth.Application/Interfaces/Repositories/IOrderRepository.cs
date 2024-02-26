using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrders();

    Task<IEnumerable<Order>> FilterOrdersAsync(DateTime? MinDate, DateTime? MaxDate, Guid? userId, Guid? statusId);

    Task<Order> GetOrderById(Guid orderId);
}