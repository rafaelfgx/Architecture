namespace Architecture.Model
{
    public sealed class UpdateUserModelValidator : UserModelValidator
    {
        public UpdateUserModelValidator()
        {
            Id();
            Name();
            Surname();
            Email();
        }
    }
}
