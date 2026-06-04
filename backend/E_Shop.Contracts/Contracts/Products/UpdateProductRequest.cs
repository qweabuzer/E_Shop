namespace E_Shop.Contracts.Contracts.Products;

public record UpdateProductRequest
{
	public string? Name { get; init; }
	public string? Description { get; init; }
	public decimal? Price { get; init; }
	public Guid? CategoryId { get; init; }
	public string? Image { get; init; }
	public bool IsAvailable { get; init; }
}
