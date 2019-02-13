using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public interface IDatabaseUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
