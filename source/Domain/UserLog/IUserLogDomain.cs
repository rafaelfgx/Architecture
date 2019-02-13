using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public interface IUserLogDomain
    {
        Task AddAsync(UserLogModel userLogModel);
    }
}
