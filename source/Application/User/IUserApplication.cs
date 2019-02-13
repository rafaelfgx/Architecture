using DotNetCore.Objects;
using DotNetCoreArchitecture.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public interface IUserApplication
    {
        Task<IDataResult<long>> AddAsync(AddUserModel addUserModel);

        Task<IResult> DeleteAsync(long userId);

        Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<UserModel>> ListAsync();

        Task<UserModel> SelectAsync(long userId);

        Task<IResult> UpdateAsync(UpdateUserModel updateUserModel);
    }
}
