using DotNetCore.Repositories;
using DotNetCoreArchitecture.Model.Entities;
using DotNetCoreArchitecture.Model.Models;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel);
    }
}
