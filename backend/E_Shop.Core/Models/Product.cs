namespace E_Shop.Core.Models;

public class Product
{
	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
	public decimal Price { get; init; }
	public Guid? CategoryId { get; init; }
	public Category? Category { get; init; }
	public string Image { get; init; }
	public bool IsAvailable { get; init; }

	public const string NoImage = "https://topzero.com/wp-content/uploads/2020/06/topzero-products-Malmo-Matte-Black-TZ-PE458M-image-003.jpg";
	public const string NoDescription = "no description";
}
