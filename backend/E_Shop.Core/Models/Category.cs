using CSharpFunctionalExtensions;

namespace E_Shop.Core.Models
{
    public class Category
    {
        private Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        //public ICollection<Product>? Products { get; }
        public static Result<Category> Create(Guid id, string name, string description)
        {
            if(string.IsNullOrEmpty(name))
                return Result.Failure<Category>("Категория должна иметь название");

            if (string.IsNullOrEmpty(description))
                return Result.Failure<Category>("Описание категории не может быть пустым");

            var category = new Category(
                id,
                name,
                description);

            return Result.Success<Category>(category);
        }

    }
}