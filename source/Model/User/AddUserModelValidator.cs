namespace Architecture.Model
{
    public sealed class AddUserModelValidator : UserModelValidator
    {
        public AddUserModelValidator()
        {
            Name();
            Surname();
            Email();
            Auth();
        }
    }
}
