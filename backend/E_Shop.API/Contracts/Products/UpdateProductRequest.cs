using System.ComponentModel;

namespace E_Shop.API.Contracts.Products
{
    public class UpdateProductRequest
    {
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;

        [DefaultValue(null)]
        public decimal? Price { get; set; } = null;

        [DefaultValue(null)]
        public Guid? CategoryId { get; set; } = null;

        [DefaultValue("")]
        public string Image { get; set; } = string.Empty;

        [DefaultValue(null)]
        public bool? IsAvailable { get; set; } = null;
    }
}
