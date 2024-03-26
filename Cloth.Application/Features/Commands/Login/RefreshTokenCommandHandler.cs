namespace Cloth.Application.Features.Commands.Login;

using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Authentication;
using Cloth.Application.Models;

using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenModel>
{
    private readonly IJwtGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenCommandHandler(IJwtGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<RefreshTokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwt = tokenHandler.ReadJwtToken(request.Token);

        string subjectClaim = jwt.Subject;

        Guid subGuid = Guid.Parse(subjectClaim);

        var user = await _unitOfWork.Users.GetByIdAsync(subGuid);

        if (user is null || user.RefreshToken != request.RefreshToken || user.TokenExpiration < DateTime.UtcNow)
        {
            throw new UnauthorizedAccessException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user, "admin");

        var refreshModel = new RefreshTokenModel
        {
            Token = token,
            RefreshToken = request.RefreshToken
        };
        return refreshModel;
    }
}