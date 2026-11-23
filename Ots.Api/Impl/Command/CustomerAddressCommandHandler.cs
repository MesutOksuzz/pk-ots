using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class CustomerAddressCommandHandler :
    IRequestHandler<CreateCustomerAddressCommand, ApiResponse<CustomerAddressResponse>>,
    IRequestHandler<UpdateCustomerAddressCommand, ApiResponse>,
    IRequestHandler<DeleteCustomerAddressCommand, ApiResponse>
{
    private readonly OtsDbContext dbContext;
    private readonly IMapper mapper;

    public CustomerAddressCommandHandler(OtsDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<CustomerAddress>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return new ApiResponse("CustomerAddress not found");

        if (!entity.IsActive)
            return new ApiResponse("CustomerAddress is not active");

        entity.IsActive = false;
        entity.UpdatedDate = DateTime.Now;
        entity.UpdatedUser = null;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<CustomerAddress>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return new ApiResponse("CustomerAddress not found");

        if (!entity.IsActive)
            return new ApiResponse("CustomerAddress is not active");

        entity.CountryCode = request.CustomerAddress.CountryCode;
        entity.City = request.CustomerAddress.City;
        entity.District = request.CustomerAddress.District;
        entity.Street = request.CustomerAddress.Street;
        entity.ZipCode = request.CustomerAddress.ZipCode;
        entity.IsDefault = request.CustomerAddress.IsDefault;
        

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse<CustomerAddressResponse>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);
        if (customer == null)
            return new ApiResponse<CustomerAddressResponse>("Customer not found");

        if (!customer.IsActive)
            return new ApiResponse<CustomerAddressResponse>("Customer is not active");

        var mapped = mapper.Map<CustomerAddress>(request.CustomerAddress);
        mapped.CustomerId = request.CustomerId;
        mapped.InsertedDate = DateTime.Now;
        mapped.InsertedUser = "test";
        mapped.IsActive = true;

        var entity = await dbContext.AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<CustomerAddressResponse>(entity.Entity);
        return new ApiResponse<CustomerAddressResponse>(response);
    }
}