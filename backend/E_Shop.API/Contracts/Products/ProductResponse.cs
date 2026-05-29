namespace E_Shop.API.Contracts.Products;

public record ProductResponse
{
	public ProductResponse(Guid id, string name, string description, decimal price, Guid? categoryId, string image, bool isAvailable)
	{
		Id = id;
		Name = name;
		Description = description;
		Price = price;
		CategoryId = categoryId;
		Image = image;
		IsAvailable = isAvailable;
	}

	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
	public decimal Price { get; init; }
	public Guid? CategoryId { get; init; }
	public string Image { get; init; }
	public bool IsAvailable { get; init; }
}
