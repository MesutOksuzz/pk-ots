using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class CustomerQueryHandler :
    IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>,
    IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
{
    private readonly OtsMsSqlDbContext context;
    private readonly IMapper mapper;

    public CustomerQueryHandler(OtsMsSqlDbContext context,IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, 
        CancellationToken cancellationToken)
    {
        var customers = await context.Set<Customer>
            ().ToListAsync(cancellationToken);
        var mapped = mapper.Map<List<CustomerResponse>>(customers);
        return mapped;
    }

    public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await context.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        var mapped = mapper.Map<CustomerResponse>(customer);
        return mapped;
    }
}