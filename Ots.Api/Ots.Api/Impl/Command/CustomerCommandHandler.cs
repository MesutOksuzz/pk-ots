using MediatR;
using Microsoft.EntityFrameworkCore;
using Ots.Api.DbContext;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;

namespace Ots.Api.Impl.Command;

public class CustomerCommandHandler
{
    private readonly OtsPostgreSqlDbContext context;

    public CustomerCommandHandler(OtsPostgreSqlDbContext context)
    {
        this.context = context;
    }
}