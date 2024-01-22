namespace Cloth.Application.Queries
{
    using Cloth.Application.Models.Dto;
    using Cloth.Application.Models.Responses;
    using MediatR;


    public class ClothQuery() : IRequest<ResponseDto>
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Size { get; set; }
        public string? Highlight { get; set; }
    }

}
