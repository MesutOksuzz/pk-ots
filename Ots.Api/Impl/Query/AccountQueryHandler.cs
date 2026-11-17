using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class AccountQueryHandler :
    IRequestHandler<GetAllAccountsQuery, ApiResponse<List<AccountResponse>>>,
    IRequestHandler<GetAccountByIdQuery, ApiResponse<AccountResponse>>
{
    private readonly OtsDbContext context;
    private readonly IMapper mapper;

    //constructor
    public AccountQueryHandler(OtsDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AccountResponse>>> Handle(GetAllAccountsQuery request,
        CancellationToken cancellationToken)
    {
        var accounts = await context.Set<Account>()
            .Include(x => x.Customer)
            .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<AccountResponse>>(accounts);
        return new ApiResponse<List<AccountResponse>>(mapped);
    }

    public async Task<ApiResponse<AccountResponse>> Handle(GetAccountByIdQuery request,
        CancellationToken cancellationToken)
    {
        var account = await context.Set<Account>()
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mapped = mapper.Map<AccountResponse>(account);
        return new ApiResponse<AccountResponse>(mapped);
    }
}















