using AutoMapper;
using Cloth.API.Models.Requests.Order;
using Cloth.API.Models.Responses.Order;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Features.Commands.Order.OrderDelete;
using Cloth.Application.Features.Commands.Order.OrderUpdate;
using Cloth.Application.Features.Queries.Order.GetOrder;
using Cloth.Application.Features.Queries.Order.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloth.API.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] Guid orderId, [FromServices] IMediator _mediator,
             [FromServices] IMapper _mapper)
        {
            var query = new GetOrderQuery(orderId);

            var data = await _mediator.Send(query);

            var response = _mapper.Map<OrderResponse>(data);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderFilterRequest orderRequest, [FromServices] IMediator _mediator,
                [FromServices] IMapper _mapper)
        {
            var query = _mapper.Map<GetOrdersQuery>(orderRequest);

            var orders = await _mediator.Send(query);

            var mappedProducts = _mapper.Map<IEnumerable<OrderResponse>>(orders);

            return Ok(mappedProducts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequest orderCreateRequest, [FromServices] IMediator _mediator,
                [FromServices] IMapper _mapper)
        {
            var command = _mapper.Map<OrderCreateCommand>(orderCreateRequest);

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<OrderCreateResponse>(result);

            return CreatedAtAction(nameof(CreateOrder), new { id = result.Id }, mappedResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateRequest orderUpdateRequest,
            [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
        {
            var command = _mapper.Map<OrderUpdateCommand>(orderUpdateRequest);

            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<OrderUpdateResponse>(result);

            return Ok(mappedResult);
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid orderId, [FromServices] IMediator _mediator)
        {
            var command = new OrderDeleteCommand(orderId);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}