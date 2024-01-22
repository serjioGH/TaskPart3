namespace Cloth.API.Mappings
{
    using AutoMapper;
    using Cloth.Application.Models.Requests;
    using Cloth.Application.Queries;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            FromRequestToQueriesMap();
        }

        private void FromRequestToQueriesMap()
        {
            CreateMap<ProductFilterRequest, ClothQuery>();
        }

    }
}
