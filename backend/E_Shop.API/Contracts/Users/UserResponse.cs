namespace E_Shop.API.Contracts.Users
{
    public record UserResponse(
        Guid Id,
        string Name,
        string Email,
        string Login,
        string Password,
        string ProfileImage);
}
