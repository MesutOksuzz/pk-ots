using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetEftTransactionByIdQuery(int Id) : IRequest<ApiResponse<EftTransactionResponse>>;
public record GetEftTransactionByParametersQuery() : IRequest<ApiResponse<List<EftTransactionResponse>>>;
public record CreateEftTransactionCommand(EftTransactionRequest EftTransaction) : IRequest<ApiResponse<TransactionResponse>>;