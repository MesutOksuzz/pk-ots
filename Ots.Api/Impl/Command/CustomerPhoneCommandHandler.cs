using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Service;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class CustomerPhoneCommandHandler :
    IRequestHandler<CreateCustomerPhoneCommand, ApiResponse<CustomerPhoneResponse>>,
    IRequestHandler<UpdateCustomerPhoneCommand, ApiResponse>,
    IRequestHandler<DeleteCustomerPhoneCommand, ApiResponse>
{
    private readonly OtsDbContext dbContext;
    private readonly IMapper mapper;
    

    public CustomerPhoneCommandHandler(OtsDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        
    }
    public async Task<ApiResponse> Handle(DeleteCustomerPhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<CustomerPhone>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return new ApiResponse("CustomerPhone not found");

        if (!entity.IsActive)
            return new ApiResponse("CustomerPhone is not active");

        entity.IsActive = false;
        entity.UpdatedDate = DateTime.Now;
        entity.UpdatedUser = null;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
    public async Task<ApiResponse> Handle(UpdateCustomerPhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<CustomerPhone>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return new ApiResponse("CustomerPhone not found");

        if (!entity.IsActive)
            return new ApiResponse("CustomerPhone is not active");

        entity.CountryCode = request.CustomerPhone.CountryCode;
        entity.PhoneNumber = request.CustomerPhone.PhoneNumber;
        entity.IsDefault = request.CustomerPhone.IsDefault;
        entity.UpdatedDate = DateTime.Now;
        entity.UpdatedUser = null;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse<CustomerPhoneResponse>> Handle(CreateCustomerPhoneCommand request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.CustomerPhone.CustomerId, cancellationToken);
        if (customer == null)
            return new ApiResponse<CustomerPhoneResponse>("Customer not found");

        if (!customer.IsActive)
            return new ApiResponse<CustomerPhoneResponse>("Customer is not active");

        var mapped = mapper.Map<CustomerPhone>(request.CustomerPhone);
        mapped.InsertedDate = DateTime.Now;
        mapped.InsertedUser = "test";
        mapped.IsActive = true;

        var entity = await dbContext.AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<CustomerPhoneResponse>(entity.Entity);
        return new ApiResponse<CustomerPhoneResponse>(response);
    }
}