using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class CountryCommandHandler:
    IRequestHandler<CreateCountryCommand, ApiResponse<CountryResponse>>,
    IRequestHandler<UpdateCountryCommand, ApiResponse>,
    IRequestHandler<DeleteCountryCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<ApiResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CountryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("Country NOT found");
        if (!entity.IsActive)
            return new ApiResponse("Country is not active");
        
        entity.IsActive = false;
        entity.UpdatedDate = DateTime.Now;
        entity.UpdatedUser = null;
        
        unitOfWork.CountryRepository.Delete(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
    public async Task<ApiResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CountryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("Country not found");

        if (!entity.IsActive)
            return new ApiResponse("Country is not active");

        entity.Name = request.Country.Name;
        
        unitOfWork.CountryRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
    public async Task<ApiResponse<CountryResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        
        var mapped = mapper.Map<Country>(request.Country);
       
        mapped.IsActive = true;
        
        var entity = await unitOfWork.CountryRepository.AddAsync(mapped);
        await unitOfWork.Complete();
        var response = mapper.Map<CountryResponse>(entity);
        return new ApiResponse<CountryResponse>(response);
    }
    
    
    
    
    
    
    
}