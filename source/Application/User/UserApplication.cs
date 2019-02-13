using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class UserApplication : IUserApplication
    {
        public UserApplication(IUserDomain userDomain)
        {
            UserDomain = userDomain;
        }

        private IUserDomain UserDomain { get; }

        public Task<IDataResult<long>> AddAsync(AddUserModel addUserModel)
        {
            return UserDomain.AddAsync(addUserModel);
        }

        public Task<IResult> DeleteAsync(long userId)
        {
            return UserDomain.DeleteAsync(userId);
        }

        public Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
        {
            return UserDomain.ListAsync(parameters);
        }

        public Task<IEnumerable<UserModel>> ListAsync()
        {
            return UserDomain.ListAsync();
        }

        public Task<UserModel> SelectAsync(long userId)
        {
            return UserDomain.SelectAsync(userId);
        }

        public Task<IResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            return UserDomain.UpdateAsync(updateUserModel);
        }
    }
}
