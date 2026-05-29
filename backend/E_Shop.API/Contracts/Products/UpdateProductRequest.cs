using System.ComponentModel;

namespace E_Shop.API.Contracts.Products
{
    public record UpdateProductRequest(
        string Name = "",
        string Description = "",
        decimal? Price = 1,
        Guid? CategoryId = null,
        string Image = "",
        bool? IsAvailable = false
    );
}
