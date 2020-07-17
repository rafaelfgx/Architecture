using DotNetCore.Domain;
using System.Collections.Generic;

namespace Architecture.Domain
{
    public sealed class FullName : ValueObject
    {
        public FullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }

        public string Surname { get; }

        protected override IEnumerable<object> Equals()
        {
            yield return Name;
            yield return Surname;
        }
    }
}
