namespace Architecture.Model
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public AuthModel Auth { get; set; }
    }
}
