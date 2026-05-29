namespace E_Shop.API.Contracts.Users;

public record UserResponse
{
	public UserResponse(Guid id, string name, string email, string login, string password, string profileImage)
	{
		Id = id;
		Name = name;
		Email = email;
		Login = login;
		Password = password;
		ProfileImage = profileImage;
	}

	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Email { get; init; }
	public string Login { get; init; }
	public string Password { get; init; }
	public string ProfileImage { get; init; }
}
