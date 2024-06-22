using CSharpFunctionalExtensions;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;

namespace E_Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Result<Guid>> CreateCategory(Category category)
        {
            var result = await _categoryRepository.Create(category);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка при созаднии категории");

            return Result.Success<Guid>(result);
        }

        public async Task<Result<Guid>> UpdateInfo(Guid id, string name, string description)
        {
            var result = await _categoryRepository.Update(id, name, description);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка при обновлении данных");

            return Result.Success<Guid>(result);
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            var result = await _categoryRepository.Delete(id);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка при удалении категории");

            return Result.Success<Guid>(result);
        }
    }
}
