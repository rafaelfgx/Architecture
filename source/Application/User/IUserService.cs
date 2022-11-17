using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Results;

namespace Architecture.Application;

public interface IUserService
{
    Task<Result<long>> AddAsync(UserModel model);

    Task<Result> DeleteAsync(long id);

    Task<UserModel> GetAsync(long id);

    Task<Grid<UserModel>> GridAsync(GridParameters parameters);

    Task<Result> InactivateAsync(long id);

    Task<IEnumerable<UserModel>> ListAsync();

    Task<Result> UpdateAsync(UserModel model);
}
