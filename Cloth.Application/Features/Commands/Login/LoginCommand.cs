using Cloth.Application.Models;

namespace Cloth.Application.Features.Commands.Login;

using MediatR;

public record LoginCommand(string Username, string Password) : IRequest<LoginModel>;