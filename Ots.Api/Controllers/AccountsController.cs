using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AccountsController : ControllerBase
{
    private readonly IMediator mediator;

    public AccountsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "admin,user")]   //burası sadece user iken 403 dönüyor !!
    public async Task<ApiResponse<List<AccountResponse>>> GetAll()
    {
        var operation = new GetAllAccountsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<ApiResponse<AccountResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetAccountByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpPost()]
    [Authorize(Roles = "admin,user")]
    public async Task<ApiResponse<AccountResponse>> Post( [FromBody] AccountRequest account)
    {
        var operation = new CreateAccountCommand( account);
        var result = await mediator.Send(operation);
        return result;
    }
    

    [HttpPut("{id}")]
    [Authorize(Roles = "admin,user")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] AccountRequest account)
    {
        var operation = new UpdateAccountCommand(id, account);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteAccountCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}