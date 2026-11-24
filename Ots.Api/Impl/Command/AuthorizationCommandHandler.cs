using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Service;
using Ots.Base;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class AuthorizationCommandHandler:
    IRequestHandler<CreateAuthorizationTokenCommand, ApiResponse<AuthorizationResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ITokenService tokenService;
    private readonly JwtConfig jwtConfig;

    public AuthorizationCommandHandler(IUnitOfWork unitOfWork,ITokenService tokenService,JwtConfig jwtconfig )
    {
        this.unitOfWork = unitOfWork;
        this.tokenService = tokenService;
        this.jwtConfig = jwtconfig;
    }
    public async Task<ApiResponse<AuthorizationResponse>> Handle(CreateAuthorizationTokenCommand request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.UserRepository.GetAllAsync(x => x.UserName == request.Request.UserName);
        var user = users.FirstOrDefault();
        if (user == null)
            return new ApiResponse<AuthorizationResponse>("User Name or Password is invalid ");
        
        var hashedPassword = PasswordGenerator.CreateMD5(request.Request.Password, user.Secret);
        if (hashedPassword != user.Password)
            return new ApiResponse<AuthorizationResponse>("User Name or Password is invalid");

        var token = tokenService.GenerateToken(user);
        var entity = new AuthorizationResponse
        {
            UserName = user.UserName,
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(1),
        };
        return new ApiResponse<AuthorizationResponse>(entity);
    }
}