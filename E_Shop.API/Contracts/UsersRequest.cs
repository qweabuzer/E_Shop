namespace E_Shop.API.Contracts
{
    public class UsersRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
    }
}
