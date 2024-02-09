using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Interfaces;

namespace Persistence.Abstractions.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    /// <summary>
    /// This method will return all the Records from the table
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
    /// <summary>
    /// This method will return the specified record from the table
    /// based on the Id which it received as an argument
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<T?> GetById(object Id)
    {
        return await _dbSet.FindAsync(Id);
    }
    /// <summary>
    /// This method will Insert one object into the table
    /// It will receive the object as an argument which needs to be inserted into the database
    /// </summary>
    /// <param name="Entity"></param>
    /// <returns></returns>
    public async Task Insert(T Entity)
    {
        await _dbSet.AddAsync(Entity);
    }
    /// <summary>
    /// This method is going to update the record in the table
    /// It will receive the object as an argument
    /// </summary>
    /// <param name="Entity"></param>
    /// <returns></returns>
    public async Task Update(T Entity)
    {
        _dbSet.Update(Entity);
    }
    /// <summary>
    /// This method is going to remove the record from the table
    /// It will receive the primary key value as an argument whose information needs to be removed from the table
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task Delete(object Id)
    {
        var entity = await _dbSet.FindAsync(Id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
    /// <summary>
    /// This method will make the changes permanent in the database
    /// </summary>
    /// <returns></returns>
    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}
