using MediatR;
using Ots.Api.Domain;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetAllCustomersQuery : IRequest<List<CustomerResponse>>;
public record GetCustomerByIdQuery(int Id) : IRequest<CustomerResponse>;
public record CreateCustomerCommand(CustomerRequest customer) : IRequest<CustomerResponse>;
public record UpdateCustomerCommand(int Id, CustomerRequest customer) : IRequest<CustomerResponse>;
public record DeleteCustomerCommand(int Id) : IRequest<CustomerResponse>;