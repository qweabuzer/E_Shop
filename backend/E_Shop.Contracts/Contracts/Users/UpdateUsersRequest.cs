namespace E_Shop.Contracts.Contracts.Users;

public record UpdateUsersRequest
{
	public string? Name { get; init; }
	public string? Email { get; init; }
	public string? Login { get; init; }
	public string? Password { get; init; }
	public string? ProfileImage { get; init; }
}
