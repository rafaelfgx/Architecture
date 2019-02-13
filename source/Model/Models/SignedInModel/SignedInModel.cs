using DotNetCoreArchitecture.Model.Enums;

namespace DotNetCoreArchitecture.Model.Models
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }
    }
}
