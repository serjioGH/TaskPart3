namespace Persistence.Abstractions.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);

    Task<T> InsertAsync(T Entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(T Entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default);
}