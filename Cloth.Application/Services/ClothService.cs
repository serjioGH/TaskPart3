using Microsoft.Extensions.Logging;

namespace Cloth.Application.Services;

using AutoMapper;
using Cloth.Application.Extensions;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Services;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using System.Linq;

public class ClothService : IClothService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ClothService> _logger;
    private readonly IMapper _mapper;

    public ClothService(IUnitOfWork unitOfWork, ILogger<ClothService> logger, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all Cloths from the repository
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        return await _unitOfWork.Cloths.GetAllCloths();
    }

    public async Task<Cloth> CreateCloth(ClothCreateCommand command)
    {
        var item = new Cloth
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            Description = command.Description,
            Price = command.Price,
            BrandId = command.BrandId,
            ClothSizes = command.Sizes.Select(size => new ClothSize
            {
                SizeId = size.SizeId,
                QuantityInStock = size.Quantity
            }).ToList(),
            ClothGroups = command.Groups.Select(group => new ClothGroup
            {
                GroupId = group.GroupId
            }).ToList()
        };

        return item;
    }

    public async Task<Cloth> UpdateClothAsync(ClothUpdateCommand command)
    {
        var cloth = await _unitOfWork.Cloths.GetClothById(command.Id);
        if (cloth == null)
        {
            throw new ItemNotFoundException($"Cloth: {command.Id} not found.");
        }

        cloth.Title = command.Title;
        cloth.Description = command.Description;
        cloth.Price = command.Price;
        cloth.BrandId = command.BrandId;

        foreach (var newSize in command.Sizes)
        {
            var existingSize = cloth.ClothSizes.FirstOrDefault(p => p.SizeId == newSize.SizeId);
            if (existingSize != null)
            {
                existingSize.QuantityInStock = newSize.Quantity;
            }
            else
            {
                cloth.ClothSizes.Add(new ClothSize
                {
                    SizeId = newSize.SizeId,
                    QuantityInStock = newSize.Quantity
                });
            }
        }

        foreach (var groups in command.Groups)
        {
            var currentGroup = cloth.ClothGroups.FirstOrDefault(p => p.GroupId == groups.GroupId);
            if (currentGroup == null)
            {
                cloth.ClothGroups.Add(new ClothGroup
                {
                    GroupId = groups.GroupId
                });
            }
        }

        _unitOfWork.Save();

        return cloth;
    }

    public async Task DeleteClothAsync(Guid id)
    {
        var cloth = await _unitOfWork.Cloths.GetClothById(id);
        if (cloth == null)
        {
            throw new ItemNotFoundException($"Cloth: {id} not found!");
        }

        await _unitOfWork.Cloths.DeleteAsync(cloth);
        _unitOfWork.Save();
    }

    public async Task<ClothFilterDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight)
    {
        try
        {
            var allItems = (await _unitOfWork.Cloths.GetAllCloths()).ToList();
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

            var response = _mapper.Map<ClothFilterDto>((filteredProducts, commonWords, allSizes, lowestPrice, highestPrice));

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogErrorFilteringCloths(ex.Message);
            throw;
        }
    }
}