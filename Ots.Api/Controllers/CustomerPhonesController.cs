using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerPhonesController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomerPhonesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<CustomerPhoneResponse>>> GetAll()
    {
        var operation = new GetAllCustomerPhonesQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<CustomerPhoneResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetCustomerPhoneByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<CustomerPhoneResponse>> Post([FromBody] CustomerPhoneRequest customerPhone)
    {
        var operation = new CreateCustomerPhoneCommand(customerPhone);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] CustomerPhoneRequest customerPhone)
    {
        var operation = new UpdateCustomerPhoneCommand(id, customerPhone);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteCustomerPhoneCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}