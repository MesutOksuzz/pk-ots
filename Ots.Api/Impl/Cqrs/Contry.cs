using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetAllCountryQuery : IRequest<ApiResponse<List<CountryResponse>>>;
public record GetCountryByIdQuery(int Id) : IRequest<ApiResponse<CountryResponse>>;
public record CreateCountryCommand(CountryRequest Country) : IRequest<ApiResponse<CountryResponse>>;
public record UpdateCountryCommand(int Id, CountryRequest Country) : IRequest<ApiResponse>;
public record DeleteCountryCommand(int Id) : IRequest<ApiResponse>;
