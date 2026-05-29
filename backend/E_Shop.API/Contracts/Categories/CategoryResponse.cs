namespace E_Shop.API.Contracts.Categories;

public record CategoryResponse
{
	public CategoryResponse(Guid id, string name, string description)
	{
		Id = id;
		Name = name;
		Description = description;
	}

	public Guid Id { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
}
