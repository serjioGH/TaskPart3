using Cloth.Application;
namespace Cloth.Infrastructure;

using Cloth.Domain.Entities;
using Cloth.Application.Interfaces;
using Cloth.Infrastructure.Config;
using Microsoft.Extensions.Options;

public class ClothRepository : IClothRepository
{
    private readonly IReadJsonFromUrlClient _readJsonFromUrlService;
    private static IEnumerable<Cloth>? _items;
    private readonly ReadJsonFromUrlConfig _jsonPathConfig;

    public ClothRepository(IReadJsonFromUrlClient readJsonFromUrlService, IOptions<ReadJsonFromUrlConfig> options)
    {
        _readJsonFromUrlService = readJsonFromUrlService ?? throw new ArgumentNullException(nameof(readJsonFromUrlService));
        _jsonPathConfig = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        if (_items == null)
        {
            _items = await _readJsonFromUrlService.GetClothsAsync($"{_jsonPathConfig.Url}{_jsonPathConfig.Name}");
        }
        
        return _items;
    }
}

