namespace E_Shop.API.Contracts.Users;

public record UsersUpdateRequest
{
	public string? Name { get; init; }
	public string? Email { get; init; }
	public string? Login { get; init; }
	public string? Password { get; init; }
	public string? ProfileImage { get; init; }
}
