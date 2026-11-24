using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class MoneyTransferQueryHandler :
    IRequestHandler<GetMoneyTransferByParametersQuery, ApiResponse<List<MoneyTransferResponse>>>,
    IRequestHandler<GetMoneyTransferByIdQuery, ApiResponse<MoneyTransferResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    //constructor
    public MoneyTransferQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<MoneyTransferResponse>>> Handle(GetMoneyTransferByParametersQuery request,
        CancellationToken cancellationToken)
    {
        var MoneyTransfer = await unitOfWork.MoneyTransferRepository.GetAllAsync();

        var mapped = mapper.Map<List<MoneyTransferResponse>>(MoneyTransfer);
        return new ApiResponse<List<MoneyTransferResponse>>(mapped);
    }

    public async Task<ApiResponse<MoneyTransferResponse>> Handle(GetMoneyTransferByIdQuery request,
        CancellationToken cancellationToken)
    {
        var MoneyTransfer = await unitOfWork.MoneyTransferRepository.GetByIdAsync(request.Id);

        var mapped = mapper.Map<MoneyTransferResponse>(MoneyTransfer);
        return new ApiResponse<MoneyTransferResponse>(mapped);
    }
}















