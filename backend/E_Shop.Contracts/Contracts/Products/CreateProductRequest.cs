using MediatR;

namespace E_Shop.Contracts.Contracts.Products;

public record CreateProductRequest : IRequest<Guid>
{
	public required string Name { get; init; }
	public required string Description { get; init; }
	public decimal Price { get; init; }
	public Guid? CategoryId { get; init; }
	public required string Image { get; init; }
	public bool IsAvailable { get; init; }
}
