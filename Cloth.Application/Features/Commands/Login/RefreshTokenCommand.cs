namespace Cloth.Application.Features.Commands.Login;

using Cloth.Application.Models;
using MediatR;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<RefreshTokenModel>;