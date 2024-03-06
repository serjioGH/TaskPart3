using Cloth.Application.Interfaces.Repositories;

namespace Cloth.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGroupRepository Groups { get; }

    ISizeRepository Sizes { get; }

    IOrderRepository Orders { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken);

    void CommitTransaction();

    void Rollback();

    IClothRepository Cloths { get; }

    IClothSizeRepository ClothSizes { get; }

    IBasketRepository Baskets { get; }

    IBasketLineRepository BasketLines { get; }
}