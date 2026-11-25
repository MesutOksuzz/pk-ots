using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CountriesController : ControllerBase
{
    private readonly IMediator mediator;

    public CountriesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")] //burası sadece user iken 403 dönüyor !!
    /*[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)] */
    [ResponseCache(CacheProfileName = "Default45")]
    public async Task<ApiResponse<List<CountryResponse>>> GetAll()
    {
        var operation = new GetAllCountryQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<ApiResponse<CountryResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetCountryByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpPost()]
    [Authorize(Roles = "admin,user")]
    public async Task<ApiResponse<CountryResponse>> Post( [FromBody] CountryRequest Country)
    {
        var operation = new CreateCountryCommand( Country);
        var result = await mediator.Send(operation);
        return result;
    }
    

    [HttpPut("{id}")]
    [Authorize(Roles = "admin,user")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] CountryRequest Country)
    {
        var operation = new UpdateCountryCommand(id, Country);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteCountryCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}