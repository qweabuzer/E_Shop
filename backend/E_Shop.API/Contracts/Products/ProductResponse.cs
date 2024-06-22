using E_Shop.Core.Models;

namespace E_Shop.API.Contracts.Products
{
    public record ProductResponse(
        Guid id,
        string name,
        string description,
        decimal price,
        Guid? categoryId,
        string image,
        bool isAvailable
        );
}
