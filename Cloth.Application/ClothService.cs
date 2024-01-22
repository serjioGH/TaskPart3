using Cloth.Application.Models;
using Cloth.Application.Models.Responses;
using Microsoft.Extensions.Logging;

namespace Cloth.Application;

using Cloth.Application.Extensions;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;

public class ClothService : IClothService
{
    private readonly IClothRepository clothRepository;
    private readonly ILogger<ClothService> _logger;
    public ClothService(IClothRepository memberRepository, ILogger<ClothService> logger)
    {
        _logger = logger;
        this.clothRepository = memberRepository;
    }

    /// <summary>
    /// Gets all Cloths from the repository
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        return await clothRepository.GetAllCloths();
    }

    /// <summary>
    /// Splits the input to form list of different highlights
    /// </summary>
    /// <param name="highlight"></param>
    /// <returns></returns>
    public List<string> GetHighlights(string? highlight)
    {
        var highlights = new List<string>();
        if (string.IsNullOrWhiteSpace(highlight))
        {
            return highlights;
        }
        else if (highlight.Contains(','))
        {
            _logger.LogInformation("Multiple highlights detected in " + highlight);
            highlights = highlight.Split(',').ToList();
        }
        else
        {
            highlights.Add(highlight);
        }

        return highlights;
    }

    public async Task<ResponseDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight)
    {
        try
        {
            var allItems = await clothRepository.GetAllCloths();
            LoggingExtensions.LogGettingCloths(_logger);

            if (allItems == null || allItems.Count() == 0)
            {
                LoggingExtensions.LogErrorGettingCloths(_logger);
                throw new ItemNotFoundException("No items found in the database.");
            }

            decimal? lowestPrice = allItems.Min(p => p.Price);
            decimal? highestPrice = allItems.Max(p => p.Price);

            List<string> allSizes = allItems.GetUniqueSizes();
            var allHighlights = this.GetHighlights(highlight);

            var commonWords = allItems.GetCommonWords();

            var filteredProducts = allItems;

            filteredProducts = filteredProducts
                .MinPriceFilter(minPrice)
                .MaxPriceFilter(maxPrice)
                .SizeFilter(size)
                .FilterWithHighlights(allHighlights);

            LoggingExtensions.LogFilteringProducts(_logger);

            return new ResponseDto
            {
                Filter = new Filter
                {
                    MinPrice = lowestPrice,
                    MaxPrice = highestPrice,
                    Sizes = allSizes,
                    CommonWords = commonWords
                },
                Products = filteredProducts,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}

