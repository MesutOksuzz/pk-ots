using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class CountryQueryHandler :
    IRequestHandler<GetAllCountryQuery, ApiResponse<List<CountryResponse>>>,
    IRequestHandler<GetCountryByIdQuery, ApiResponse<CountryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    //constructor
    public CountryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<CountryResponse>>> Handle(GetAllCountryQuery request,
        CancellationToken cancellationToken)
    {
        var Countrys = await unitOfWork.CountryRepository.GetAllAsync();

        var mapped = mapper.Map<List<CountryResponse>>(Countrys);
        return new ApiResponse<List<CountryResponse>>(mapped);
    }

    public async Task<ApiResponse<CountryResponse>> Handle(GetCountryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var Country = await unitOfWork.CountryRepository.GetByIdAsync(request.Id);

        var mapped = mapper.Map<CountryResponse>(Country);
        return new ApiResponse<CountryResponse>(mapped);
    }
}















