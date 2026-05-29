using E_Shop.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.API.Contracts.Products
{
        public record ProductRequest(
        string Name = "",
        string Description = "",
        decimal Price = 1,
        Guid? CategoryId = null,
        string Image = "",
        bool IsAvailable = false
        );
}
