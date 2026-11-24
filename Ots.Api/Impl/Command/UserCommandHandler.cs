using AutoMapper;
using MediatR;
using Ots.Api.Domain;
using Ots.Api.Impl.Cqrs;
using Ots.Api.Impl.Service;
using Ots.Base;
using Ots.Base.ApiResponse;
using Ots.Schema;

namespace Ots.Api.Impl.Command;

public class UserCommandHandler :
    IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>,
    IRequestHandler<UpdateUserCommand, ApiResponse>,
    IRequestHandler<DeleteUserCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IAppSession appSession;
    

    public UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IAppSession appSession)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.appSession = appSession;
    }
    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("User not found");

        if (!entity.IsActive)
            return new ApiResponse("User is not active");

        entity.IsActive = false;

        unitOfWork.UserRepository.Delete(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("User not found");

        if (!entity.IsActive)
            return new ApiResponse("User is not active");

        entity.FirstName = request.User.FirstName;
        entity.LastName = request.User.LastName;
        entity.Role = request.User.Role;
        

        unitOfWork.UserRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<User>(request.User);
        
        mapped.OpenDate = DateTime.Now;
        mapped.IsActive = true;
        mapped.Secret = PasswordGenerator.GeneratePassword(30);

        var password = "123456";
        mapped.Password = PasswordGenerator.CreateMD5(password, mapped.Secret);
        
        var entity = await unitOfWork.UserRepository.AddAsync(mapped);
        await unitOfWork.Complete();

        var response = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(response);
    }
}