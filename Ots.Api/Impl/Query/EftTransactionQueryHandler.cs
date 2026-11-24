using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class EftTransactionQueryHandler :
    IRequestHandler<GetEftTransactionByParametersQuery, ApiResponse<List<EftTransactionResponse>>>,
    IRequestHandler<GetEftTransactionByIdQuery, ApiResponse<EftTransactionResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    //constructor
    public EftTransactionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EftTransactionResponse>>> Handle(GetEftTransactionByParametersQuery request,
        CancellationToken cancellationToken)
    {
        var EftTransactions = await unitOfWork.EftTransactionRepository.GetAllAsync("Account","Account.Customer");

        var mapped = mapper.Map<List<EftTransactionResponse>>(EftTransactions);
        return new ApiResponse<List<EftTransactionResponse>>(mapped);
    }

    public async Task<ApiResponse<EftTransactionResponse>> Handle(GetEftTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var EftTransaction = await unitOfWork.EftTransactionRepository.GetByIdAsync(request.Id, "Account", "Account.Customer");

        var mapped = mapper.Map<EftTransactionResponse>(EftTransaction);
        return new ApiResponse<EftTransactionResponse>(mapped);
    }
}















