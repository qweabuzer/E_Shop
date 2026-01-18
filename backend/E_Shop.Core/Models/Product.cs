using CSharpFunctionalExtensions;

namespace E_Shop.Core.Models
{
    public class Product
    {
        private Product(Guid id, string name, string description, decimal price, Guid? categoryId, string image, bool isAvailable)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Image = image;
            IsAvailable = isAvailable;

        }
        public Guid Id { get;}
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public Guid? CategoryId { get; }
        public Category? Category { get; } = null;
        public string Image { get; } = string.Empty;
        public bool IsAvailable { get; }

        private const string NoImage = "https://topzero.com/wp-content/uploads/2020/06/topzero-products-Malmo-Matte-Black-TZ-PE458M-image-003.jpg";
        private const string NoDiscription = "no description";

        public static Result<Product> Create(Guid id, string name, string description, decimal price, Guid? categoryId, string image, bool isAvailable)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Product>("Название не может быть пустым");

            if (name.Length > 300)
                return Result.Failure<Product>("Длина названия не может превышать 300 симмволов");

            if (string.IsNullOrWhiteSpace(description))
                description = NoDiscription;

            if (price < 1)
                return Result.Failure<Product>("Цена не может быть меньше 1");

            if (string.IsNullOrWhiteSpace(image))
                image = NoImage;

            var product = new Product(
                id,
                name,
                description,
                price,
                categoryId,
                image,
                isAvailable);

            return Result.Success<Product>(product);
        }
    }
}
