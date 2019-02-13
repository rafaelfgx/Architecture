using DotNetCore.Mapping;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Model.Entities;
using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class UserLogDomain : IUserLogDomain
    {
        public UserLogDomain
        (
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLogRepository userLogRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLogRepository = userLogRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLogRepository UserLogRepository { get; }

        public Task AddAsync(UserLogModel userLogModel)
        {
            var userLogEntity = userLogModel.Map<UserLogEntity>();

            UserLogRepository.AddAsync(userLogEntity);

            return DatabaseUnitOfWork.SaveChangesAsync();
        }
    }
}
