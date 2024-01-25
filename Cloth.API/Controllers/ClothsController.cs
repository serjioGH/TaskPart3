namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.API.Models.Requests;
using Cloth.API.Models.Responses;
using Cloth.Application.Features.Queries.GetCloths;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ClothsController : BaseController
{
    // GET: api/<ClothsController>
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] ClothFilterRequest request, [FromServices] ISender _mediator,
         [FromServices] IMapper _mapper)
    {
        var query = _mapper.Map<ClothQuery>(request);

        var data = await _mediator.Send(query);

        var response = _mapper.Map<ClothResponseDto>(data);

        return Ok(response);
    }

}

