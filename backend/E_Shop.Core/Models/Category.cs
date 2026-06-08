namespace E_Shop.Core.Models;

public class Category
{
	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
	public ICollection<Product>? Products { get; }
}
