using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class CustomerCommandHandler : 
    IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerResponse>>,
    IRequestHandler<UpdateCustomerCommand, ApiResponse>,
    IRequestHandler<DeleteCustomerCommand, ApiResponse>


{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
   // yukarıdaki methodlar implement edildi.
   public async Task<ApiResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
   {
       var entity = await unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
       if (entity == null)
           return new ApiResponse("Customer NOT found");
       if (!entity.IsActive)
           return new ApiResponse("Customer is not active");
        
       entity.IsActive = false;

       unitOfWork.CustomerRepository.Delete(entity);
       await unitOfWork.Complete();
       return new ApiResponse();
   }
   public async Task<ApiResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
   {
       var entity = await unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
       if (entity == null)
           return new ApiResponse("Customer NOT found");

       if (!entity.IsActive)
           return new ApiResponse("Customer is not active");
       
       entity.FirstName = request.customer.FirstName;
       entity.MiddleName = request.customer.MiddleName;
       entity.LastName = request.customer.LastName;
       entity.Email = request.customer.Email;

       unitOfWork.CustomerRepository.Update(entity);
       await unitOfWork.Complete();
       return new ApiResponse();
   }
    public async Task<ApiResponse<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Customer>(request.customer);
        
        mapped.OpenDate =  DateTime.Now;
        
        mapped.CustomerNumber = new Random().Next(100000, 9999999);
        mapped.IsActive = true;
        
       var entity = await unitOfWork.CustomerRepository.AddAsync(mapped);
        await unitOfWork.Complete();
        var response = mapper.Map<CustomerResponse>(entity);
        return new ApiResponse<CustomerResponse>(response);
    }
}