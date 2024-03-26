namespace Cloth.API.Controllers;

using AutoMapper;
using Cloth.API.Models.Requests.Login;
using Cloth.API.Models.Responses.Login;
using Cloth.Application.Features.Commands.Login;
using Cloth.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class UsersController : BaseController
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(AuthenticateRequest model, [FromServices] IMediator _mediator, [FromServices] IMapper _mapper)
    {
        var command = new LoginCommand(model.Username, model.Password);

        var result = await _mediator.Send(command);
        if (result == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        var mappedResult = _mapper.Map<LoginResponse>(result);

        return Ok(mappedResult);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest request, [FromServices] IMapper _mapper, [FromServices] IMediator _mediator)
    {
        var command = new RefreshTokenCommand(request.Token, request.RefreshToken);

        var result = await _mediator.Send(command);

        var mappedResult = _mapper.Map<RefreshTokenResponse>(result);

        return Ok(mappedResult);
    }

    [HttpPost]
    public async Task<IActionResult> Logout(LogoutRequest request, [FromServices] IMapper _mapper)
    {
        return Ok();
    }
}