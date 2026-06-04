namespace E_Shop.Contracts.Contracts.Categories;

public record CategoryResponse
{
	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
}
