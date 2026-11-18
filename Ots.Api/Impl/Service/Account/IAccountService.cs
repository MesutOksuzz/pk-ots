using Ots.Base.ApiResponse;

namespace Ots.Api.Impl.Service;

public interface IAccountService
{
    Task<ApiResponse> CreateOutgoingAccountTransaction(long accountId, decimal amount, decimal feeAmount , string description,string refNumber);

    Task<ApiResponse> CreateInComingAccountTransaction(long accountId, decimal amount , string description,string refNumber);
}

    
