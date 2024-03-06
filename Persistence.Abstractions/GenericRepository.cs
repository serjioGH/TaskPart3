using Dapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Constants;
using Persistence.Abstractions.Exceptions;
using Persistence.Abstractions.Interfaces;
using System.Data;

namespace Persistence.Abstractions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    private readonly IDbConnection _connection;

    public GenericRepository(DbContext dbContext, IDbConnection connection)
    {
        _dbContext = dbContext;
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    /// <summary>
    /// This method will return all the Records from the table
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        IEnumerable<T> entities;
        try
        {
            entities = await _connection.QueryAsync<T>(QueryConstants.SelectEntity(typeof(T).Name));
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while getting all entities.", ex);
        }

        return entities;
    }

    /// <summary>
    /// This method will return the specified record from the table
    /// based on the Id which it received as an argument
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        T? entity;
        try
        {
            var query = QueryConstants.SelectEntityById(typeof(T).Name);
            entity = await _connection.QuerySingleAsync<T>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while getting the entity by id.", ex);
        }

        return entity;
    }

    /// <summary>
    /// This method will Insert one object into the table
    /// It will receive the object as an argument which needs to be inserted into the database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entry.Entity;
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while adding the entity to database.", ex);
        }
    }

    /// <summary>
    /// This method is going to update the record in the table
    /// It will receive the object as an argument
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            _dbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while updating the entity.", ex);
        }
    }

    public async Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            return entity != null;
        }
        catch (Exception ex)
        {
            throw new DbException("Checking if the entity exists by id failed.", ex);
        }
    }

    public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while deleting an entity.", ex);
        }
    }
}