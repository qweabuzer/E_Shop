namespace E_Shop.API.Contracts.Products;

public record ProductRequest
{
	public required string Name { get; init; }
	public required string Description { get; init; }
	public decimal Price { get; init; }
	public Guid? CategoryId { get; init; }
	public required string Image { get; init; }
	public bool IsAvailable { get; init; }
}
