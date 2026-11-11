using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Schema;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomersController(IMediator mediator)
    {
        this.mediator = mediator ;
    }

    [HttpGet("GetAll")]
    public async Task<List<CustomerResponse>> GetAll()
    {
        var operation = new GetAllCustomersQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetById/{id}")]
    public async Task<CustomerResponse> GetById([FromRoute] int id)
    {
        var operation = new GetCustomerByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost]
    public async Task<CustomerResponse> Post([FromBody] CustomerRequest customer)
    {
        var operation = new CreateCustomerCommand(customer);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPut("{id}")]
    public async Task<CustomerResponse> Put([FromRoute] int id, [FromBody] CustomerRequest customer)
    {
        var operation = new UpdateCustomerCommand(id, customer);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<CustomerResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteCustomerCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}