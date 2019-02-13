using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [HttpPost]
        public Task<IDataResult<long>> AddAsync(AddUserModel addUserModel)
        {
            return UserApplication.AddAsync(addUserModel);
        }

        [HttpDelete("{userId}")]
        public Task<IResult> DeleteAsync(long userId)
        {
            return UserApplication.DeleteAsync(userId);
        }

        [HttpGet]
        public Task<IEnumerable<UserModel>> ListAsync()
        {
            return UserApplication.ListAsync();
        }

        [HttpGet("{userId}")]
        public Task<UserModel> SelectAsync(long userId)
        {
            return UserApplication.SelectAsync(userId);
        }

        [HttpPut("{userId}")]
        public Task<IResult> UpdateAsync(long userId, UpdateUserModel updateUserModel)
        {
            updateUserModel.UserId = userId;

            return UserApplication.UpdateAsync(updateUserModel);
        }
    }
}
