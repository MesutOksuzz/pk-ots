using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;

namespace Ots.Api.Impl.Command;

public class CustomerCommandHandler : 
    IRequestHandler<CreateCustomerCommand, Customer>,
    IRequestHandler<UpdateCustomerCommand, Customer>,
    IRequestHandler<DeleteCustomerCommand, Customer>


{
    private readonly OtsMsSqlDbContext dbContext;

    public CustomerCommandHandler(OtsMsSqlDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
   // yukarıdaki methodlar implement edildi.
    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
       var entity = await dbContext.AddAsync(request.customer, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity.Entity;
    }
    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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

        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            //to do 
            // alt satırda istersek hard delete ya da soft delete yapabiliriz ,biz soft yaptık. 
        }
        
        entity.IsActive = false;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}