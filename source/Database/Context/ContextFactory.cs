namespace Architecture.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<Context>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContextFactory;").Options);
}
