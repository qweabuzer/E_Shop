using E_Shop.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.API.Contracts.Products
{
    public class ProductRequest
    {
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;

        [DefaultValue(1)]
        public decimal Price { get; set; } = decimal.One;

        [DefaultValue(null)]
        public Guid? CategoryId { get; set; } = null;

        [DefaultValue("")]
        public string Image { get; set; } = string.Empty;

        [DefaultValue(false)]
        public bool IsAvailable { get; set; } = false;
    }
}
