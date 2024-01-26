using Microsoft.Extensions.Logging;

namespace Cloth.Application.Services;

using AutoMapper;
using Cloth.Application.Extensions;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using System.Linq;

public class ClothService : IClothService
{
    private readonly IClothRepository clothRepository;
    private readonly ILogger<ClothService> _logger;
    private readonly IMapper _mapper;
    public ClothService(IClothRepository memberRepository, ILogger<ClothService> logger, IMapper mapper)
    {
        _logger = logger;
        clothRepository = memberRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all Cloths from the repository
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        return await clothRepository.GetAllCloths();
    }

    public async Task<ClothDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight)
    {
        try
        {
            var allItems = (await clothRepository.GetAllCloths()).ToList();
            _logger.LogGettingCloths();

            if (allItems == null || allItems.Count == 0)
            {
                _logger.LogErrorGettingCloths();
                throw new ItemNotFoundException("No items found in the database.");
            }

            decimal? lowestPrice = allItems.Min(p => p.Price);
            decimal? highestPrice = allItems.Max(p => p.Price);

            List<string> allSizes = allItems.GetUniqueSizes();
            var allHighlights = highlight.GetHighlights();

            var commonWords = allItems.GetCommonWords();

            var filteredProducts = allItems;

            filteredProducts = filteredProducts
                .MinPriceFilter(minPrice)
                .MaxPriceFilter(maxPrice)
                .SizeFilter(size)
                .FilterWithHighlights(allHighlights);
            _logger.LogFilteringProducts();

            var response = _mapper.Map<ClothDto>((filteredProducts, commonWords, allSizes, lowestPrice, highestPrice));

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogErrorFilteringCloths(ex.Message);
            throw;
        }
    }
}

