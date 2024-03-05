using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Constants.DapperQueries;
using Cloth.Persistence.PostgreSQL.Context;
using Dapper;
using Persistence.Abstractions.Repositories;
using Serilog;
using System.Data;

namespace Cloth.Persistence.Ef.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    private readonly ClothInventoryDbContext _dbContext;
    private readonly IDbConnection _dbConnection;
    private readonly ILogger _logger;

    public BasketRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection,
        ILogger logger) : base(dbContext, dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;
        _logger = logger;
    }

    public async Task<Basket> GetBasketByUserIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var basketDictionary = new Dictionary<Guid, Basket>();
            var basketLinesDictionary = new Dictionary<Guid, BasketLine>();

            var basket = await _dbConnection.QueryAsync<Basket, User, BasketLine, Domain.Entities.Cloth, Size, Basket>(
                ReadFromDbConstants.BasketConstants.GetBasketByUserIdQuery,
                (basket, user, basketLine, cloth, size) =>
                {
                    Basket basketEntry;
                    if (!basketDictionary.TryGetValue(basket.Id, out basketEntry))
                    {
                        basketDictionary.Add(basket.Id, basketEntry = basket);
                        basketEntry.User = user;
                        basketEntry.BasketLines = new List<BasketLine>();
                    }

                    BasketLine blEntry;
                    if (basketLine != null && !basketLinesDictionary.TryGetValue(basketLine.Id, out blEntry))
                    {
                        basketLinesDictionary.Add(basketLine.Id, blEntry = basketLine);
                        blEntry.Cloth = cloth;
                        blEntry.Size = size;
                        basketEntry.BasketLines.Add(blEntry);
                    }

                    return basketEntry;
                },
                new { UserId = id },
                splitOn: $"{nameof(User.Id)},{nameof(BasketLine.Id)},{nameof(Domain.Entities.Cloth.Id)},{nameof(Size.Id)}"
            );

            var result = basketDictionary.Values.FirstOrDefault();
            if (result == null)
            {
                throw new ItemNotFoundException($"Basket of User not found.");
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving Basket of User.", ex);
        }
    }
}