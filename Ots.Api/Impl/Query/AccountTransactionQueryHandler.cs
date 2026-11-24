using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class AccountTransactionQueryHandler :
    IRequestHandler<GetAccountTransactionByParametersQuery, ApiResponse<List<AccountTransactionResponse>>>,
    IRequestHandler<GetAccountTransactionByIdQuery, ApiResponse<AccountTransactionResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AccountTransactionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AccountTransactionResponse>>> Handle(GetAccountTransactionByParametersQuery request, CancellationToken cancellationToken)
    {
        var AccountTransaction = await unitOfWork.AccountTransactionRepository.GetAllAsync("Account", "Account.Customer");

        var mapped = mapper.Map<List<AccountTransactionResponse>>(AccountTransaction);
        return new ApiResponse<List<AccountTransactionResponse>>(mapped);
    }

    public async Task<ApiResponse<AccountTransactionResponse>> Handle(GetAccountTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var AccountTransaction = await unitOfWork.AccountTransactionRepository.GetByIdAsync(request.Id, "Account", "Account.Customer");

        var mapped = mapper.Map<AccountTransactionResponse>(AccountTransaction);
        return new ApiResponse<AccountTransactionResponse>(mapped);
    }
}