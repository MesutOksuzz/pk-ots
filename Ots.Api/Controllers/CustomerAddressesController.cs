using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerAddressesController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomerAddressesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<CustomerAddressResponse>>> GetAll()
    {
        var operation = new GetAllCustomerAddressesQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<CustomerAddressResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetCustomerAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpPost("ByCustomerId/{CustomerId}")]
    public async Task<ApiResponse<CustomerAddressResponse>> Post([FromRoute] long CustomerId, [FromBody] CustomerAddressRequest customerAddress)
    {
        var operation = new CreateCustomerAddressCommand(CustomerId, customerAddress);
        var result = await mediator.Send(operation);
        return result;
    }
    

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] CustomerAddressRequest CustomerAddress)
    {
        var operation = new UpdateCustomerAddressCommand(id, CustomerAddress);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteCustomerAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}