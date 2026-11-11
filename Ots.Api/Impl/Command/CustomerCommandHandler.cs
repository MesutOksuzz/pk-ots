using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class CustomerCommandHandler : 
    IRequestHandler<CreateCustomerCommand, CustomerResponse>,
    IRequestHandler<UpdateCustomerCommand, CustomerResponse>,
    IRequestHandler<DeleteCustomerCommand, CustomerResponse>


{
    private readonly OtsMsSqlDbContext dbContext;
    private readonly IMapper mapper;

    public CustomerCommandHandler(OtsMsSqlDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
   // yukarıdaki methodlar implement edildi.
    public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Customer>(request.customer);
       var entity = await dbContext.AddAsync(request.customer, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        var response = mapper.Map<CustomerResponse>(entity.Entity);
        return response;
    }
    public async Task<CustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            //to do 
        }
        entity.FirstName = request.customer.FirstName;
        entity.MiddleName = request.customer.MiddleName;
        entity.LastName = request.customer.LastName;
        entity.Email = request.customer.Email;
        entity.UpdateDate = DateTime.Now;
        entity.UpdateUser = null;

        await dbContext.SaveChangesAsync(cancellationToken);
        var mapped = mapper.Map<CustomerResponse>(entity);
        
        return mapped;
    }

    public async Task<CustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            //to do 
            // alt satırda istersek hard delete ya da soft delete yapabiliriz ,biz soft yaptık. 
        }
        
        entity.IsActive = false;
        
        await dbContext.SaveChangesAsync(cancellationToken);

        var mapped = mapper.Map<CustomerResponse>(entity);
        
        return mapped;
    }
}