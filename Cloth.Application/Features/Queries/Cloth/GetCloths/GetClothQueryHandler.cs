namespace Cloth.Application.Features.Queries.Cloths.GetCloths;

using AutoMapper;
using Cloth.Application.Extensions;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetClothQueryHandler : IRequestHandler<ClothQuery, ClothFilterDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GetClothQueryHandler> _logger;

    public GetClothQueryHandler(IUnitOfWork unitOfWork, ILogger<GetClothQueryHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ClothFilterDto> Handle(ClothQuery request, CancellationToken cancellationToken)
    {
        _logger.LogRequestHandlerMessage(request);
        List<Cloth> allItems = (List<Cloth>)await _unitOfWork.Cloths.GetAllCloths();
        decimal? lowestPrice = allItems.Min(p => p.Price);
        decimal? highestPrice = allItems.Max(p => p.Price);

        List<string> allSizes = allItems.ToList().GetUniqueSizes();
        var allHighlights = request.Highlight.GetHighlights();
        var commonWords = allItems.GetCommonWords();
        var filteredProducts = allItems;

        filteredProducts = filteredProducts
            .MinPriceFilter(request.MinPrice)
            .MaxPriceFilter(request.MaxPrice)
            .SizeFilter(request.Size)
            .FilterWithHighlights(allHighlights);
        _logger.LogFilteringProducts();

        var response = _mapper.Map<ClothFilterDto>((filteredProducts, commonWords, allSizes, lowestPrice, highestPrice));
        return response;
    }
}