namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.API.Models.Requests.Cloth;
using Cloth.API.Models.Responses.Cloth;
using Cloth.Application.Features.Commands.Cloths.ClothCreate;
using Cloth.Application.Features.Commands.Cloths.ClothDelete;
using Cloth.Application.Features.Commands.Cloths.ClothUpdate;
using Cloth.Application.Features.Queries.Cloth.GetCloth;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = IdentityData.AdminUserPolicy)]
public class ClothsController : BaseController
{
    // GET: api/<ClothsController>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] ClothFilterRequest request, [FromServices] IMediator _mediator,
         [FromServices] IMapper _mapper)
    {
        var query = _mapper.Map<ClothQuery>(request);

        var data = await _mediator.Send(query);

        var response = _mapper.Map<ClothResponseDto>(data);

        return Ok(response);
    }

    [HttpGet("{ClothId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCloth([FromRoute] ClothGetRequest request, [FromServices] IMediator _mediator,
     [FromServices] IMapper _mapper)
    {
        var query = _mapper.Map<GetClothByIdQuery>(request);

        var data = await _mediator.Send(query);

        var response = _mapper.Map<ClothGetResponse>(data);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCloth(
        [FromBody] ClothCreateRequest clothCreateRequest, [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        var command = _mapper.Map<ClothCreateCommand>(clothCreateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<ClothCreateResponse>(result);

        return CreatedAtAction(nameof(CreateCloth), new { id = result.Id }, mappedResult);
    }

    [HttpPut("{clothId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCloth(
        [FromRoute] Guid clothId, [FromBody] ClothUpdateRequest clothUpdateRequest, [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        clothUpdateRequest.Id = clothId;

        var command = _mapper.Map<ClothUpdateCommand>(clothUpdateRequest);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<ClothUpdateResponse>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{clothId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCloth(
        [FromRoute] Guid clothId, [FromServices] IMediator _mediator)
    {
        var command = new DeleteClothCommand(clothId);

        await _mediator.Send(command);

        return NoContent();
    }
}