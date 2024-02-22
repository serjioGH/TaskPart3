namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.API.Models.Requests.Basket;
using Cloth.API.Models.Responses.Basket;
using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Application.Features.Commands.Basket.BasketLineDelete;
using Cloth.Application.Features.Commands.Basket.BasketLineDeleteAll;
using Cloth.Application.Features.Commands.Basket.BasketLineUpdate;
using Cloth.Application.Features.Queries.Basket.GetBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class BasketController : BaseController
{
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBasket([FromRoute] Guid userId, [FromServices] IMediator _mediator,
        [FromServices] IMapper _mapper)
    {
        var query = new GetBasketQuery { UserId = userId };

        var basket = await _mediator.Send(query);

        var mappedProducts = _mapper.Map<BasketResponse>(basket);

        return Ok(mappedProducts);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddBasketLine([FromBody] BasketLineCreateRequest basketLineCreateRequest,
        [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        var command = _mapper.Map<BasketLineCreateCommand>(basketLineCreateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<BasketLineResponse>(result);

        return CreatedAtAction(nameof(AddBasketLine), new { id = result.BasketLineId }, mappedResult);
    }

    [HttpPut("basketLines/{basketLineId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBasketLine(Guid basketLineId, [FromBody] BasketLineUpdateRequest basketLineUpdateRequest,
        [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        basketLineUpdateRequest.BasketLineId = basketLineId;
        var command = _mapper.Map<BasketLineUpdateCommand>(basketLineUpdateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<BasketLineUpdateResponse>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBasket([FromRoute] Guid userId, [FromServices] IMediator _mediator)
    {
        var command = new BasketLineDeleteAllCommand(userId);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("basketLines/{basketLineId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBasketLine([FromRoute] Guid basketLineId, [FromServices] IMediator _mediator)
    {
        var command = new BasketLineDeleteCommand(basketLineId);

        await _mediator.Send(command);

        return NoContent();
    }
}