using DotNetCoreArchitecture.Model.Entities;
using DotNetCoreArchitecture.Model.Enums;
using DotNetCoreArchitecture.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreArchitecture.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var signInModel = new SignInModel("admin", "admin");

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 1,
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                Login = signInModel.LoginHash(),
                Password = signInModel.PasswordHash(),
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active
            });
        }
    }
}
