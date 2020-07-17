using DotNetCore.Domain;

namespace Architecture.Domain
{
    public sealed class Email : ValueObject<string>
    {
        public Email(string value) : base(value) { }
    }
}
