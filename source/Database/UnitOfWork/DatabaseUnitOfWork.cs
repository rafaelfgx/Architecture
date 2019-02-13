using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public DatabaseUnitOfWork(DatabaseContext context)
        {
            Context = context;
        }

        private DatabaseContext Context { get; }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
