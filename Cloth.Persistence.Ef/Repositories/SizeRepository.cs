using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

public class SizeRepository : GenericRepository<Size>, ISizeRepository
{
    public SizeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}