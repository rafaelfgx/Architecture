using Architecture.Domain;
using DotNetCore.Repositories;

namespace Architecture.Database;

public interface IAuthRepository : IRepository<Auth>
{
    Task<bool> AnyByLoginAsync(string login);

    Task<Auth> GetByLoginAsync(string login);
}
