using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class EftTransactionQueryHandler :
    IRequestHandler<GetEftTransactionByParametersQuery, ApiResponse<List<EftTransactionResponse>>>,
    IRequestHandler<GetEftTransactionByIdQuery, ApiResponse<EftTransactionResponse>>
{
    private readonly OtsDbContext context;
    private readonly IMapper mapper;

    //constructor
    public EftTransactionQueryHandler(OtsDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EftTransactionResponse>>> Handle(GetEftTransactionByParametersQuery request,
        CancellationToken cancellationToken)
    {
        var EftTransactions = await context.Set<EftTransaction>()
            .Include(x => x.Account)
            .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<EftTransactionResponse>>(EftTransactions);
        return new ApiResponse<List<EftTransactionResponse>>(mapped);
    }

    public async Task<ApiResponse<EftTransactionResponse>> Handle(GetEftTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var EftTransaction = await context.Set<EftTransaction>()
            .Include(x => x.Account).ThenInclude(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mapped = mapper.Map<EftTransactionResponse>(EftTransaction);
        return new ApiResponse<EftTransactionResponse>(mapped);
    }
}















