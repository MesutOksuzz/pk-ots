using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
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
    private readonly OtsDbContext context;
    private readonly IMapper mapper;

    public AccountTransactionQueryHandler(OtsDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AccountTransactionResponse>>> Handle(GetAccountTransactionByParametersQuery request, CancellationToken cancellationToken)
    {
        var AccountTransaction = await context.Set<AccountTransaction>()
            .Include(x => x.Account).ThenInclude(x =>x.Customer)
            .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<AccountTransactionResponse>>(AccountTransaction);
        return new ApiResponse<List<AccountTransactionResponse>>(mapped);
    }

    public async Task<ApiResponse<AccountTransactionResponse>> Handle(GetAccountTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var AccountTransaction = await context.Set<AccountTransaction>()
            .Include(x=>x.Account).ThenInclude(x=>x.Customer)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mapped = mapper.Map<AccountTransactionResponse>(AccountTransaction);
        return new ApiResponse<AccountTransactionResponse>(mapped);
    }
}