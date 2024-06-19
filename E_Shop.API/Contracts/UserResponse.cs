namespace E_Shop.API.Contracts
{
    public record UserResponse(
        Guid Id,
        string Name,
        string Email,
        string Login,
        string Password,
        string ProfileImage);
}
