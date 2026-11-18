using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetMoneyTransferByIdQuery(int Id) : IRequest<ApiResponse<MoneyTransferResponse>>;
public record GetMoneyTransferByParametersQuery() : IRequest<ApiResponse<List<MoneyTransferResponse>>>;
public record CreateMoneyTransferCommand(MoneyTransferRequest MoneyTransfer) : IRequest<ApiResponse<TransactionResponse>>;