using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

    public record CreateAuthorizationTokenCommand(AuthorizationRequest Request) : IRequest<ApiResponse<AuthorizationResponse>>;


