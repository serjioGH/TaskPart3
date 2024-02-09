namespace Persistence.Abstractions.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(object Id);
    Task Insert(T Entity);
    Task Update(T Entity);
    Task Delete(object Id);
    Task Save();
}
