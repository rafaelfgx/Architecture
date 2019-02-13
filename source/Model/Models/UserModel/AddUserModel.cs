namespace DotNetCoreArchitecture.Model.Models
{
    public class AddUserModel : UserModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
