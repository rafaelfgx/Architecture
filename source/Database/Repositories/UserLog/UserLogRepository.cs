using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Model.Entities;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
