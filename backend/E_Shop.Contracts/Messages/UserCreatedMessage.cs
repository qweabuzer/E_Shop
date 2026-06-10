namespace E_Shop.Contracts.Messages;
public record UserCreatedMessage
{
	public Guid UserId{ get; init; }
	public DateTime CreatedTime { get; init; }
}
