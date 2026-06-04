namespace E_Shop.Core.Models;

public class Users
{
	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Email { get; init; }
	public string Login { get; init; }
	public string Password { get; init; }
	public string? ProfileImage { get; init; }

	public const string NoImage = "https://www.no5.com/media/1772/place-holder-image.png";
	public static int UserCounter { get; set; }
}
