using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

//inherit
public record GetAllCustomerAddressesQuery : IRequest<ApiResponse<List<CustomerAddressResponse>>>;
public record GetCustomerAddressByIdQuery(int Id) : IRequest<ApiResponse<CustomerAddressResponse>>;
public record CreateCustomerAddressCommand(long CustomerId,CustomerAddressRequest CustomerAddress) : IRequest<ApiResponse<CustomerAddressResponse>>;
public record UpdateCustomerAddressCommand(int Id, CustomerAddressRequest CustomerAddress) : IRequest<ApiResponse>;
public record DeleteCustomerAddressCommand(int Id) : IRequest<ApiResponse>;