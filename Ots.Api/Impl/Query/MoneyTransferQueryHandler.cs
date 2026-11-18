using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Query;

public class MoneyTransferQueryHandler :
    IRequestHandler<GetMoneyTransferByParametersQuery, ApiResponse<List<MoneyTransferResponse>>>,
    IRequestHandler<GetMoneyTransferByIdQuery, ApiResponse<MoneyTransferResponse>>
{
    private readonly OtsDbContext context;
    private readonly IMapper mapper;

    //constructor
    public MoneyTransferQueryHandler(OtsDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<MoneyTransferResponse>>> Handle(GetMoneyTransferByParametersQuery request,
        CancellationToken cancellationToken)
    {
        var MoneyTransfer = await context.Set<MoneyTransfer>()
            .ToListAsync(cancellationToken);

        var mapped = mapper.Map<List<MoneyTransferResponse>>(MoneyTransfer);
        return new ApiResponse<List<MoneyTransferResponse>>(mapped);
    }

    public async Task<ApiResponse<MoneyTransferResponse>> Handle(GetMoneyTransferByIdQuery request,
        CancellationToken cancellationToken)
    {
        var MoneyTransfer = await context.Set<MoneyTransfer>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mapped = mapper.Map<MoneyTransferResponse>(MoneyTransfer);
        return new ApiResponse<MoneyTransferResponse>(mapped);
    }
}















