namespace E_Shop.API.Contracts.Users
{
    public record UsersRequest(
        string Name = "",
        string Email = "",
        string Login = "",
        string Password = "",
        string ProfileImage = ""
    );
}
