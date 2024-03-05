using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;
using Serilog;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

public class SizeRepository : GenericRepository<Size>, ISizeRepository
{
    public SizeRepository(DbContext dbContext, IDbConnection dbConnection,
        ILogger logger) : base(dbContext, dbConnection)
    {
    }
}