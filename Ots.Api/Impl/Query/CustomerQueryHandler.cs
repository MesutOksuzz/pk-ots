using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class CustomerQueryHandler :
    IRequestHandler<GetAllCustomersQuery, ApiResponse<List<CustomerResponse>>>,
    IRequestHandler<GetCustomerByIdQuery, ApiResponse<CustomerResponse>>
{
    private readonly OtsDbContext context;
    private readonly IMapper mapper;
    public CustomerQueryHandler(OtsDbContext context,IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetAllCustomersQuery request, 
        CancellationToken cancellationToken)
    {
        var customers = await context.Set<Customer>
            ().ToListAsync(cancellationToken);
        var mapped = mapper.Map<List<CustomerResponse>>(customers);
        return new ApiResponse<List<CustomerResponse>>(mapped);
    }
    public async Task<ApiResponse<CustomerResponse>> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await context.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        var mapped = mapper.Map<CustomerResponse>(customer);
        return new ApiResponse<CustomerResponse>(mapped);
    }
}