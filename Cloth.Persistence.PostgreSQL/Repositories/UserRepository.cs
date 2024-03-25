using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Constants.DapperQueries;
using Cloth.Persistence.PostgreSQL.Context;
using Dapper;
using Persistence.Abstractions;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

using Cloth.Domain.Entities;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection) : base(dbContext, dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User> GetUser(string password, string username)
    {
        User user = null;
        try
        {
            user = await _dbConnection.QuerySingleAsync<User>(ReadFromDbConstants.UserConstants.GetUserByPassAndUsername, new { Password = password, Username = username });
        }
        catch (Exception ex)
        {
            throw new DbException("An error occurred while getting user from database.", ex);
        }

        return user;
    }
}