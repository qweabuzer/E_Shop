

namespace E_Shop.DataAccess.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public string Image { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
