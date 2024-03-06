using Cloth.Application.Extensions;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Constants.DapperQueries;
using Cloth.Persistence.PostgreSQL.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;
using Serilog;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ClothInventoryDbContext _dbContext;
    private readonly IDbConnection _dbConnection;
    private readonly ILogger _logger;

    public OrderRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection,
        ILogger logger) : base(dbContext, dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;
        _logger = logger;
    }

    public async Task<IEnumerable<Order>> FilterOrdersAsync(DateTime? minDate, DateTime? maxDate, Guid? userId, Guid? statusId, CancellationToken cancellationToken)
    {
        var ordersLookup = new Dictionary<Guid, Order>();

        try
        {
            await _dbConnection.QueryAsync<Order, User, OrderStatus, OrderLines, Order>(
                ReadFromDbConstants.OrderConstants.GetOrderDetailsQuery,
                (order, user, orderStatus, orderLine) =>
                {
                    if (!ordersLookup.TryGetValue(order.Id, out Order currentOrder))
                    {
                        currentOrder = order;
                        currentOrder.OrderLines = new List<OrderLines>();
                        ordersLookup.Add(currentOrder.Id, currentOrder);
                    }

                    if (user != null)
                    {
                        currentOrder.User = user;
                    }

                    if (orderLine != null)
                    {
                        currentOrder.OrderLines.Add(orderLine);
                    }

                    if (orderStatus != null)
                    {
                        currentOrder.Status = orderStatus;
                    }

                    return currentOrder;
                },
                splitOn: $"{nameof(User.Id)},{nameof(OrderLines.Id)},{nameof(OrderStatus.Id)}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while retrieving order.", ex);
        }

        if (ordersLookup is null || ordersLookup.Count is 0)
        {
            throw new ItemNotFoundException("No items found in the database.");
        }

        var allItems = new List<Order>(ordersLookup.Values);

        allItems = allItems.OrderUserFilter(userId)
            .OrderStatusFilter(statusId)
            .MinDateFilter(minDate)
            .MaxDateFilter(maxDate);

        return allItems;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        try
        {
            var result = await _dbContext.Orders
                 .Include(o => o.User)
                 .Include(o => o.Status)
                 .Where(p => p.IsDeleted == false)
                 .ToListAsync();

            return result;
        }
        catch (ArgumentNullException ex)
        {
            throw new ItemNotFoundException($"Retrieving all orders resulted in an error.", ex);
        }
    }

    public async Task<Order> GetOrderById(Guid orderId, CancellationToken cancellationToken)
    {
        var ordersLookup = new Dictionary<Guid, Order>();
        try
        {
            await _dbConnection.QueryAsync<Order, User, OrderStatus, OrderLines, Order>(
                ReadFromDbConstants.OrderConstants.GetOrderByIdQuery,
                (order, user, orderStatus, orderLine) =>
                {
                    if (!ordersLookup.TryGetValue(order.Id, out Order currentOrder))
                    {
                        currentOrder = order;
                        currentOrder.OrderLines = new List<OrderLines>();
                        ordersLookup.Add(currentOrder.Id, currentOrder);
                    }

                    if (user != null)
                    {
                        currentOrder.User = user;
                    }

                    if (orderLine != null)
                    {
                        currentOrder.OrderLines.Add(orderLine);
                    }

                    if (orderStatus != null)
                    {
                        currentOrder.Status = orderStatus;
                    }

                    return currentOrder;
                },
                new { OrderId = orderId },
                splitOn: $"{nameof(User.Id)},{nameof(OrderLines.Id)},{nameof(OrderStatus.Id)}");

            if (ordersLookup is null || ordersLookup.Count is 0)
            {
                throw new ItemNotFoundException($"Order not found.");
            }

            return ordersLookup.Count > 0 ? ordersLookup[orderId] : null;
        }
        catch (Exception ex)
        {
            throw new DbException($"Error while retrieving order.", ex);
        }
    }
}