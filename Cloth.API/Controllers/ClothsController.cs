namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.Application.Models.Requests;
using Cloth.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ClothsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClothsController(IMediator mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }
    // GET: api/<ClothsController>
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] ProductFilterRequest request)
    {
        var query = _mapper.Map<ClothQuery>(request);

        var response = await _mediator.Send(query);

        return Ok(new { filter = response.Filter, products = response.Products });
    }

}

