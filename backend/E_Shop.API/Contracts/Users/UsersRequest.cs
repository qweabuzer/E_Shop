using System.ComponentModel;

namespace E_Shop.API.Contracts.Users
{
    public class UsersRequest
    {
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;
        [DefaultValue("")]
        public string Email { get; set; } = string.Empty;
        [DefaultValue("")]
        public string Login { get; set; } = string.Empty;
        [DefaultValue("")]
        public string Password { get; set; } = string.Empty;
        [DefaultValue("")]
        public string ProfileImage { get; set; } = string.Empty;
    }
}
