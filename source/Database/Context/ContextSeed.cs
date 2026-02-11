namespace Architecture.Database;

public static class ContextSeed
{
    extension(ModelBuilder builder)
    {
        public void Seed() => builder.SeedUsers();

        private void SeedUsers()
        {
            builder.Entity<User>(entity => entity.HasData(new
            {
                Id = 1L,
                Name = "Administrator",
                Email = "administrator@administrator.com",
                Status = Status.Active
            }));

            var salt = new Guid("79005744-e69a-4b09-996b-08fe0b70cbb9");

            builder.Entity<Auth>(entity => entity.HasData(new
            {
                Id = 1L,
                Login = "admin",
                Password = new HashService().Create("admin", salt.ToString()),
                Salt = salt,
                Roles = Roles.User | Roles.Admin,
                UserId = 1L
            }));
        }
    }
}
