using DotNetCore.Mapping;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Model.Entities;
using DotNetCoreArchitecture.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class UserDomain : IUserDomain
    {
        public UserDomain
        (
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserRepository userRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserRepository = userRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserRepository UserRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddUserModel addUserModel)
        {
            var validationResult = new AddUserModelValidator().Valid(addUserModel);

            if (!validationResult.Success)
            {
                return new ErrorDataResult<long>(validationResult.Message);
            }

            var signInModel = new SignInModel(addUserModel.Login, addUserModel.Password);

            addUserModel.Login = signInModel.LoginHash();

            addUserModel.Password = signInModel.PasswordHash();

            var userEntity = addUserModel.Map<UserEntity>();

            await UserRepository.AddAsync(userEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(userEntity.UserId);
        }

        public async Task<IResult> DeleteAsync(long userId)
        {
            await UserRepository.DeleteAsync(userId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
        {
            return await UserRepository.ListAsync<UserModel>(parameters);
        }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await UserRepository.ListAsync<UserModel>();
        }

        public async Task<UserModel> SelectAsync(long userId)
        {
            return await UserRepository.SelectAsync<UserModel>(userId);
        }

        public async Task<IResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            var validationResult = new UpdateUserModelValidator().Valid(updateUserModel);

            if (!validationResult.Success)
            {
                return validationResult;
            }

            var userEntity = updateUserModel.Map<UserEntity>();

            var userEntityDatabase = await UserRepository.SelectAsync(userEntity.UserId);

            userEntity = userEntityDatabase.Map(userEntity);

            await UserRepository.UpdateAsync(userEntity, userEntity.UserId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}
