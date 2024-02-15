using Cloth.Domain.Entities;

namespace Cloth.Application.Extensions;

public static class ListOrderExtension
{
    public static List<Order> MinDateFilter(this List<Order> orders, DateTime? minDate)
    {
        if (minDate.HasValue)
        {
            return orders.Where(p => p.CreatedOn >= minDate.Value).ToList();
        }

        return orders;
    }

    public static List<Order> MaxDateFilter(this List<Order> orders, DateTime? maxDate)
    {
        if (maxDate.HasValue)
        {
            return orders.Where(p => p.CreatedOn <= maxDate.Value).ToList();
        }

        return orders;
    }

    public static List<Order> OrderStatusFilter(this List<Order> orders, Guid? statusId)
    {
        if (statusId.HasValue)
        {
            return orders.Where(p => p.StatusId == statusId.Value).ToList();
        }

        return orders;
    }

    public static List<Order> OrderUserFilter(this List<Order> orders, Guid? userId)
    {
        if (userId.HasValue)
        {
            return orders.Where(p => p.UserId == userId.Value).ToList();
        }

        return orders;
    }
}