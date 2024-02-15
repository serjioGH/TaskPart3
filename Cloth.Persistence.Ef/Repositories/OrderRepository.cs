using Cloth.Application.Extensions;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.Ef.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    protected readonly ClothInventoryDbContext _dbContext;

    public OrderRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> FilterOrdersAsync(DateTime? minDate, DateTime? maxDate, Guid? userId, Guid? statusId)
    {
        var allItems = await _dbContext.Orders
            .Include(o => o.User)
            .Include(o => o.Status)
            .Where(p => p.IsDeleted == false)
            .ToListAsync();

        if (allItems == null || allItems.Count == 0)
        {
            throw new ItemNotFoundException("No items found in the database.");
        }

        allItems = allItems.OrderUserFilter(userId)
            .OrderStatusFilter(statusId)
            .MinDateFilter(minDate)
            .MaxDateFilter(maxDate);

        return allItems;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var result = await _dbContext.Orders
             .Include(o => o.User)
             .Include(o => o.Status)
             .Where(p => p.IsDeleted == false)
             .ToListAsync();

        return result;
    }

    public async Task<Order> GetOrderById(Guid orderId)
    {
        try
        {
            var result = await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Status)
                .Include(o => o.OrderLines)
                    .ThenInclude(od => od.Cloth)
                       .ThenInclude(p => p.ClothSizes)
                           .ThenInclude(cs => cs.Size)
                .Where(p => p.IsDeleted == false)
                .SingleAsync(o => o.Id == orderId);
            return result;
        }
        catch (Exception)
        {
            throw new ItemNotFoundException($"Order: {orderId} not found.");
        }
    }
}