namespace E_Shop.API.Contracts.Users;

public record CreateUsersRequest
{
	public required string Name { get; init; }
	public required string Email { get; init; }
	public required string Login { get; init; }
	public required string Password { get; init; }
	public string? ProfileImage { get; init; }
}
