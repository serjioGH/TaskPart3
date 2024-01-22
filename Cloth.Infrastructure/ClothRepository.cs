using Cloth.Application;
namespace Cloth.Infrastructure;

using Cloth.Domain.Entities;
using Cloth.Application.Interfaces;

public class ClothRepository : IClothRepository
{
    //TODO: move to appsettings
    public string jsonPath = "https://run.mocky.io/v3/97aa328f-6f5d-458a-9fa4-55fe58eaacc9";
    private readonly IReadJsonFromUrlClient _readJsonFromUrlService;
    private static IEnumerable<Cloth>? _items;

    public ClothRepository(IReadJsonFromUrlClient readJsonFromUrlService)
    {
        _readJsonFromUrlService = readJsonFromUrlService ?? throw new ArgumentNullException(nameof(readJsonFromUrlService));
    }

    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        if (_items == null)
        {
            _items = await _readJsonFromUrlService.GetClothsAsync(jsonPath);
        }
        
        return _items;
    }
}

