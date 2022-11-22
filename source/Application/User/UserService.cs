using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;

namespace Architecture.Application;

public sealed class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserFactory _userFactory;
    private readonly IUserRepository _userRepository;

    public UserService
    (
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IUserFactory userFactory,
        IUserRepository userRepository
    )
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
        _userFactory = userFactory;
        _userRepository = userRepository;
    }

    public async Task<Result<long>> AddAsync(UserModel model)
    {
        var validationResult = new AddUserModelValidator().Validation(model);

        if (validationResult.IsError) return Result<long>.Error(validationResult.Message);

        var addAuthResult = await _authService.AddAsync(model.Auth);

        if (addAuthResult.IsError) return Result<long>.Error(addAuthResult.Message);

        var user = _userFactory.Create(model, addAuthResult.Value);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result<long>.Success(user.Id);
    }

    public async Task<Result> DeleteAsync(long id)
    {
        var authId = await _userRepository.GetAuthIdByUserIdAsync(id);

        await _userRepository.DeleteAsync(id);

        await _authService.DeleteAsync(authId);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public Task<UserModel> GetAsync(long id)
    {
        return _userRepository.GetModelAsync(id);
    }

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
    {
        return _userRepository.GridAsync(parameters);
    }

    public async Task<Result> InactivateAsync(long id)
    {
        var user = new User(id);

        user.Inactivate();

        await _userRepository.UpdateStatusAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<IEnumerable<UserModel>> ListAsync()
    {
        return await _userRepository.ListModelAsync();
    }

    public async Task<Result> UpdateAsync(UserModel model)
    {
        var validationResult = new UpdateUserModelValidator().Validation(model);

        if (validationResult.IsError) return validationResult;

        var user = await _userRepository.GetAsync(model.Id);

        if (user is null) return Result.Success();

        user.Update(model.FirstName, model.LastName, model.Email);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
