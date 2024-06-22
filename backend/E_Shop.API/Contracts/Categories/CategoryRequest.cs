using System.ComponentModel;

namespace E_Shop.API.Contracts.Categories
{
    public class CategoryRequest
    {
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;
        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;
    }
}
