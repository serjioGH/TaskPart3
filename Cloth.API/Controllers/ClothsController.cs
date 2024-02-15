namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.API.Models.Requests.Cloth;
using Cloth.API.Models.Responses.Cloth;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothDelete;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ClothsController : BaseController
{
    // GET: api/<ClothsController>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ClothFilterRequest request, [FromServices] IMediator _mediator,
         [FromServices] IMapper _mapper)
    {
        var query = _mapper.Map<ClothQuery>(request);

        var data = await _mediator.Send(query);

        var response = _mapper.Map<ClothResponseDto>(data);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCloth(
        [FromBody] ClothCreateRequest productCreateRequest, [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        var command = _mapper.Map<ClothCreateCommand>(productCreateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<ClothCreateResponse>(result);

        return CreatedAtAction(nameof(CreateCloth), new { id = result.Id }, mappedResult);
    }

    [HttpPut("{clothId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProduct(
        [FromQuery] Guid clothId, [FromBody] ClothUpdateRequest productUpdateRequest, [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        productUpdateRequest.Id = clothId;

        var command = _mapper.Map<ClothUpdateCommand>(productUpdateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<ClothUpdateResponse>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProduct(
        [FromRoute] Guid clothId, [FromServices] IMediator _mediator)
    {
        var command = new DeleteClothCommand(clothId);

        await _mediator.Send(command);

        return NoContent();
    }
}