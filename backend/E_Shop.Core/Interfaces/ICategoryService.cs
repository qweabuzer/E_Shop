using CSharpFunctionalExtensions;
using E_Shop.Contracts.Contracts.Categories;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Core.Interfaces;

public interface ICategoryService
{
	Task<List<Category>> GetAllCategories();
	Task<ActionResult<Guid>> CreateCategory(CreateCategoryRequest request);
	Task<ActionResult<Guid>> UpdateInfo(CreateCategoryRequest request, Guid id);
	Task<Result<Guid>> Delete(Guid id);
}
