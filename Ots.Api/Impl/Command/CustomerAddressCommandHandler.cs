using AutoMapper;
using MediatR;
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
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CustomerAddressRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("CustomerAddress not found");

        if (!entity.IsActive)
            return new ApiResponse("CustomerAddress is not active");

        entity.IsActive = false;

        unitOfWork.CustomerAddressRepository.Delete(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CustomerAddressRepository.GetByIdAsync(request.Id);
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
        
        unitOfWork.CustomerAddressRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<CustomerAddressResponse>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
            return new ApiResponse<CustomerAddressResponse>("Customer not found");

        if (!customer.IsActive)
            return new ApiResponse<CustomerAddressResponse>("Customer is not active");

        var mapped = mapper.Map<CustomerAddress>(request.CustomerAddress);
        mapped.CustomerId = request.CustomerId;
        mapped.IsActive = true;

        var entity = await unitOfWork.CustomerAddressRepository.AddAsync(mapped);
        await unitOfWork.Complete();

        var response = mapper.Map<CustomerAddressResponse>(entity);
        return new ApiResponse<CustomerAddressResponse>(response);
    }
}