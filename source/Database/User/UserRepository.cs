using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public sealed class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }

        public Task<long> GetAuthIdByUserIdAsync(long id)
        {
            return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.AuthId).SingleOrDefaultAsync();
        }

        public Task<UserModel> GetModelAsync(long id)
        {
            return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.Model).SingleOrDefaultAsync();
        }

        public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
        {
            return Queryable.Select(UserExpression.Model).GridAsync(parameters);
        }

        public Task InactivateAsync(User user)
        {
            return UpdatePartialAsync(user.Id, new { user.Status });
        }

        public async Task<IEnumerable<UserModel>> ListModelAsync()
        {
            return await Queryable.Select(UserExpression.Model).ToListAsync();
        }
    }
}
