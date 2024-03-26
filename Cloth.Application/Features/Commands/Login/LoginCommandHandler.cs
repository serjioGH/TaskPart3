namespace Cloth.Application.Features.Commands.Login;

using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Authentication;
using Cloth.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
{
    private readonly IJwtGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(IJwtGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginModel> Handle(LoginCommand model, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUser(model.Password, model.Username);

        var token = _jwtTokenGenerator.GenerateToken(user, "admin");
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(32);

        user.RefreshToken = refreshToken;
        user.TokenExpiration = DateTime.UtcNow.AddDays(1);

        await _unitOfWork.Users.UpdateAsync(user);
        await _unitOfWork.SaveAsync(cancellationToken);

        var loginModel = new LoginModel
        {
            Username = user.Username,
            Token = token,
            RefreshToken = refreshToken
        };

        return loginModel;
    }
}