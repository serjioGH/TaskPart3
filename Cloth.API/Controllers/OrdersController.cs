using AutoMapper;
using Cloth.API.Models.Requests.Cloth;
using Cloth.API.Models.Requests.Order;
using Cloth.API.Models.Responses.Cloth;
using Cloth.API.Models.Responses.Order;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Features.Queries.Order.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloth.API.Controllers
{
    public class OrdersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ClothFilterRequest request, [FromServices] ISender _mediator,
             [FromServices] IMapper _mapper)
        {
            var query = _mapper.Map<ClothQuery>(request);

            var data = await _mediator.Send(query);

            var response = _mapper.Map<ClothResponseDto>(data);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderFilterRequest orderRequest, [FromServices] ISender _mediator,
                [FromServices] IMapper _mapper)
        {
            var query = _mapper.Map<GetOrdersQuery>(orderRequest);

            var orders = await _mediator.Send(query);

            var mappedProducts = _mapper.Map<IEnumerable<OrderResponse>>(orders);

            return Ok(mappedProducts);
        }
    }
}
