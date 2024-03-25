namespace Cloth.API.Controllers;

using Cloth.Application.Interfaces.Services;
using Cloth.Application.Models;
using Microsoft.AspNetCore.Mvc;

public class UsersController : BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model,
        IUserService service)
    {
        var response = await service.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}