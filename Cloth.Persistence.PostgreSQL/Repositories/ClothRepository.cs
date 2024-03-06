using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Constants.DapperQueries;
using Cloth.Persistence.PostgreSQL.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

using Cloth.Domain.Entities;

public class ClothRepository : GenericRepository<Cloth>, IClothRepository
{
    private readonly IDbConnection _dbConnection;

    public ClothRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection) : base(dbContext, dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        try
        {
            var clothsDictionary = new Dictionary<Guid, Cloth>();
            var cloths = await _dbConnection.QueryAsync<Cloth, Brand, ClothGroup, ClothSize, Size, Group, Cloth>(
                ReadFromDbConstants.ClothConstants.GetAllClothsQuery,
                (cloth, brand, clothGroup, clothSize, size, group) =>
                {
                    if (!clothsDictionary.TryGetValue(cloth.Id, out var clothEntry))
                    {
                        clothEntry = cloth;
                        clothEntry.Brand = brand;
                        clothEntry.ClothGroups = new List<ClothGroup>();
                        clothEntry.ClothSizes = new List<ClothSize>();
                        clothsDictionary.Add(clothEntry.Id, clothEntry);
                    }

                    if (clothGroup != null && !clothEntry.ClothGroups.Any(cg => cg.GroupId == clothGroup.GroupId))
                    {
                        clothGroup.Group = group;
                        clothEntry.ClothGroups.Add(clothGroup);
                    }

                    if (clothSize != null && !clothEntry.ClothSizes.Any(cs => cs.SizeId == clothSize.SizeId))
                    {
                        clothSize.Size = size;
                        clothEntry.ClothSizes.Add(clothSize);
                    }

                    return clothEntry;
                },
                splitOn: $"{nameof(Brand.Id)},{nameof(ClothGroup.ClothId)},{nameof(ClothSize.ClothId)},{nameof(Size.Id)},{nameof(Group.Id)}");

            return cloths.ToList();
        }
        catch (Exception)
        {
            throw new DbException($"Error retrieving all items.");
        }
    }

    public async Task<Cloth> GetClothById(Guid clothId)
    {
        Cloth? result;
        try
        {
            var clothsDictionary = new Dictionary<Guid, Cloth>();
            result = await _dbConnection.QueryFirstOrDefaultAsync<Cloth>(ReadFromDbConstants.ClothConstants.GetClothQuery, new { Id = clothId });

            var cloths = await _dbConnection.QueryAsync<Cloth, Brand, ClothGroup, Group, ClothSize, Size, Cloth>(
                ReadFromDbConstants.ClothConstants.GetClothQuery,
                (cloth, brand, clothGroup, group, clothSize, size) =>
                {
                    if (!clothsDictionary.TryGetValue(cloth.Id, out var clothEntry))
                    {
                        clothEntry = cloth;
                        clothEntry.Brand = brand;
                        clothEntry.ClothGroups = new List<ClothGroup>();
                        clothEntry.ClothSizes = new List<ClothSize>();
                        clothsDictionary.Add(clothEntry.Id, clothEntry);
                    }

                    if (clothGroup != null && !clothEntry.ClothGroups.Any(cg => cg.GroupId == clothGroup.GroupId))
                    {
                        clothGroup.Cloth = clothEntry;
                        clothGroup.Group = group;
                        clothEntry.ClothGroups.Add(clothGroup);
                    }

                    if (clothSize != null && !clothEntry.ClothSizes.Any(cg => cg.SizeId == clothSize.SizeId))
                    {
                        clothSize.Cloth = clothEntry;
                        clothSize.Size = size;
                        clothSize.ClothId = cloth.Id;
                        clothEntry.ClothSizes.Add(clothSize);
                    }

                    return clothEntry;
                },
                new { Id = clothId },
                splitOn: $"{nameof(Brand.Id)},{nameof(ClothGroup.GroupId)},{nameof(Group.Id)},{nameof(ClothSize.SizeId)},{nameof(Size.Id)}");
            result = cloths.FirstOrDefault();

            if (result is null)
            {
                throw new ItemNotFoundException($"Cloth not found.");
            }

            return result;
        }
        catch (Exception)
        {
            throw new DbException($"Retrieving Cloth resulted in an error.");
        }
    }

    public override async Task<Cloth> InsertAsync(Cloth cloth, CancellationToken cancellationToken = default)
    {
        try
        {
            cloth.Id = Guid.NewGuid();
            await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.InsertClothQuery, cloth);
            foreach (var group in cloth.ClothGroups)
            {
                await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.InsertClothGroup, new { ClothId = cloth.Id, GroupId = group.GroupId });
            }

            foreach (var size in cloth.ClothSizes)
            {
                await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.InsertClothSize, new { ClothId = cloth.Id, SizeId = size.SizeId, QuantityInStock = size.QuantityInStock });
            }

            var groups = await _dbConnection.QueryAsync<ClothGroup, Group, ClothGroup>(
                ReadFromDbConstants.ClothConstants.GetClothGroups,
                (clothGroup, group) =>
                {
                    clothGroup.Group = group;
                    return clothGroup;
                },
                new { ClothId = cloth.Id },
                splitOn: $"{nameof(Group.Id)}");

            var sizes = await _dbConnection.QueryAsync<ClothSize, Size, ClothSize>(ReadFromDbConstants.ClothConstants.GetClothSizes,
                (clothSize, size) =>
                {
                    clothSize.Size = size;
                    return clothSize;
                },
                new { ClothId = cloth.Id },
                splitOn: $"{nameof(Group.Id)}");

            cloth.ClothGroups = groups.ToList();
            cloth.ClothSizes = sizes.ToList();

            return cloth;
        }
        catch (Exception)
        {
            throw new DbException($"Inserting Cloth resulted in an error.");
        }
    }

    public override async Task UpdateAsync(Cloth cloth, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.UpdateCloth, cloth);

            await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.DeleteClothGroups, new { ClothId = cloth.Id });

            await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.DeleteClothSizes, new { ClothId = cloth.Id });

            foreach (var size in cloth.ClothSizes)
            {
                await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.InsertClothSize, new
                {
                    ClothId = cloth.Id,
                    SizeId = size.SizeId,
                    QuantityInStock = size.QuantityInStock
                });
            }

            foreach (var group in cloth.ClothGroups)
            {
                await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.InsertClothGroup, new
                {
                    ClothId = cloth.Id,
                    GroupId = group.GroupId
                });
            }
        }
        catch (Exception)
        {
            throw new DbException($"Updating Cloth resulted in an error.");
        }
    }

    public override async Task DeleteAsync(Cloth cloth, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbConnection.ExecuteAsync(CommandConstants.ClothConstants.DeletedClothSet, new { IsDeleted = true, Id = cloth.Id });
        }
        catch
        {
            throw new DbException($"Deleting Cloth resulted in an error.");
        }
    }
}