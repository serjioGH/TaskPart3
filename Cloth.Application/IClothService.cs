namespace Cloth.Application;

using Cloth.Application.Models.Responses;
using System.Threading.Tasks;

public interface IClothService
{
    Task<ResponseDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);
}

