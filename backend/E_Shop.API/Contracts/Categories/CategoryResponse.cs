namespace E_Shop.API.Contracts.Categories
{
    public record CategoryResponse(
        Guid id,
        string name,
        string description);
}
