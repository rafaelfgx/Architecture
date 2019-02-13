using DotNetCore.Repositories;
using DotNetCoreArchitecture.Model.Entities;

namespace DotNetCoreArchitecture.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
