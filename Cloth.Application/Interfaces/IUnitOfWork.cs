namespace Cloth.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGroupRepository Groups { get; }
    ISizeRepository Sizes { get; }
    IOrderRepository Orders { get; }
    int Save();
    IClothRepository Cloths { get; }
}
