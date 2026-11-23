using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;
using Microsoft.AspNetCore.Authorization;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthorizationController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthorizationController(IMediator mediator)
    {
        this.mediator = mediator ;
    }
    
    [HttpPost ("Token")]
    public async Task<ApiResponse<AuthorizationResponse>> Post([FromBody] AuthorizationRequest request)
    {
        var operation = new CreateAuthorizationTokenCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }
}