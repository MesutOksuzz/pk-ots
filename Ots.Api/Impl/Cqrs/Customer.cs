using MediatR;
using Ots.Api.Domain;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetAllCustomersQuery : IRequest<ApiResponse<List<CustomerResponse>>>;
public record GetCustomerByIdQuery(int Id) : IRequest<ApiResponse<CustomerResponse>>;
public record CreateCustomerCommand(CustomerRequest customer) : IRequest<ApiResponse<CustomerResponse>>;
public record UpdateCustomerCommand(int Id, CustomerRequest customer) : IRequest<ApiResponse>;
public record DeleteCustomerCommand(int Id) : IRequest<ApiResponse>;