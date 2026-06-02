namespace E_Shop.API.Contracts.Categories;

public record CreateCategoryRequest
{
	public required string Name { get; init; }
	public required string Description { get; init; }
}
