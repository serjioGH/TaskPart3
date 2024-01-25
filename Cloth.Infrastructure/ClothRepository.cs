namespace Cloth.Infrastructure;

using Cloth.Domain.Entities;
using Cloth.Application.Interfaces;
using Cloth.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

public class ClothRepository : IClothRepository
{
    private readonly IHttpServiceClient _readJsonFromUrlService;
    private static IEnumerable<Cloth>? _items;

    public ClothRepository(IHttpServiceClient readJsonFromUrlService, IOptions<MockyHttpConfiguration> options)
    {
        _readJsonFromUrlService = readJsonFromUrlService ?? throw new ArgumentNullException(nameof(readJsonFromUrlService));
    }

    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        if (_items == null)
        {
            _items = await _readJsonFromUrlService.GetClothsAsync();
        }
        
        return _items;
    }
}

