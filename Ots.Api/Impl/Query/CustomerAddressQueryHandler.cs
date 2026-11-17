using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class CustomerAddressQueryHandler :
    IRequestHandler<GetAllCustomerAddressesQuery, ApiResponse<List<CustomerAddressResponse>>>,
    IRequestHandler<GetCustomerAddressByIdQuery, ApiResponse<CustomerAddressResponse>>
{
    private readonly OtsDbContext context;
    private readonly IMapper mapper;

    public CustomerAddressQueryHandler(OtsDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<CustomerAddressResponse>>> Handle(GetAllCustomerAddressesQuery request, CancellationToken cancellationToken)
    {
        var customerAddresses = await context.Set<CustomerAddress>()
            .Include(x => x.Customer)
            .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<CustomerAddressResponse>>(customerAddresses);
        return new ApiResponse<List<CustomerAddressResponse>>(mapped);
    }

    public async Task<ApiResponse<CustomerAddressResponse>> Handle(GetCustomerAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var customerAddress = await context.Set<CustomerAddress>()
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mapped = mapper.Map<CustomerAddressResponse>(customerAddress);
        return new ApiResponse<CustomerAddressResponse>(mapped);
    }
}