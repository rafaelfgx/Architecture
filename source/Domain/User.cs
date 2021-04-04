using DotNetCore.Domain;

namespace Architecture.Domain
{
    public class User : Entity<long>
    {
        public User
        (
            Name name,
            Email email,
            Auth auth
        )
        {
            Name = name;
            Email = email;
            Auth = auth;
            Activate();
        }

        public User(long id) : base(id) { }

        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public Status Status { get; private set; }

        public Auth Auth { get; private set; }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }

        public void UpdateName(string firstName, string lastName)
        {
            Name = new Name(firstName, lastName);
        }

        public void UpdateEmail(string email)
        {
            Email = new Email(email);
        }
    }
}
