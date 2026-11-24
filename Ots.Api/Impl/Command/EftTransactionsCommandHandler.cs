using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Service;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class EftTransactionsCommandHandler : 
    IRequestHandler<CreateEftTransactionCommand, ApiResponse<TransactionResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IAccountService accountService;

    public EftTransactionsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IAccountService accountService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.accountService = accountService;
    }

    public async Task<ApiResponse<TransactionResponse>> Handle(CreateEftTransactionCommand request, CancellationToken cancellationToken)
    {
        
        var account = await unitOfWork.AccountRepository.GetByIdAsync(request.EftTransaction.AccountId);
        if (account == null)
            return new ApiResponse<TransactionResponse>("Account not found");

        if (!account.IsActive)
            return new ApiResponse<TransactionResponse>("Account is not active");

        var feeAmount = request.EftTransaction.Amount * 0.01m;
        var refNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        
        if (account.Balance < request.EftTransaction.Amount + feeAmount )
            return new ApiResponse<TransactionResponse>("account balance is not enough");

        var eftTransaction = new EftTransaction()
        {
            AccountId = request.EftTransaction.AccountId,
            ReveiverIban = request.EftTransaction.ReveiverIban,
            ReceiverName = request.EftTransaction.ReceiverName,
            Description = request.EftTransaction.Description,
            Amount = request.EftTransaction.Amount,
            PaymentCategoryCode = request.EftTransaction.PaymentCategoryCode,
            TransactionDate = DateTime.Now,
            ReferenceNumber = refNumber,
            FeeAmount = feeAmount,
            
        };
        await unitOfWork.EftTransactionRepository.AddAsync(eftTransaction);
        await unitOfWork.Complete();

        var responseAccount = await accountService.CreateOutgoingAccountTransaction(account.Id, request.EftTransaction.Amount,
            feeAmount, request.EftTransaction.Description, refNumber);
        if (responseAccount.Success == false)

            return new  ApiResponse<TransactionResponse> (responseAccount.Message);

        var transactionResponse = new TransactionResponse
        {

            Amount = eftTransaction.Amount,
            FeeAmount = feeAmount,
            TransactionDate = eftTransaction.TransactionDate,
            ReferenceNumber = eftTransaction.ReferenceNumber,

        };
        
        return new ApiResponse<TransactionResponse>(transactionResponse);
    }
}