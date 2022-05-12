using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Results;

namespace Architecture.Application;

public interface IAuthService
{
    Task<IResult<Auth>> AddAsync(AuthModel model);

    Task DeleteAsync(long id);

    Task<IResult<TokenModel>> SignInAsync(SignInModel model);
}
