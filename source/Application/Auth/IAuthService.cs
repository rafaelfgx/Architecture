using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Results;

namespace Architecture.Application;

public interface IAuthService
{
    Task<Result<Auth>> AddAsync(AuthModel model);

    Task DeleteAsync(long id);

    Task<Result<TokenModel>> SignInAsync(SignInModel model);
}
