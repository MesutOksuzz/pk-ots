using MediatR;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Cqrs;

public record GetAccountTransactionByIdQuery(int Id) : IRequest<ApiResponse<AccountTransactionResponse>>;
public record GetAccountTransactionByParametersQuery() : IRequest<ApiResponse<List<AccountTransactionResponse>>>;