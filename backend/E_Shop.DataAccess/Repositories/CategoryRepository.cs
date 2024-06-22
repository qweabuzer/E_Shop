
using AutoMapper;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace E_Shop.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EShopDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;
        private readonly IMapper _mapper;

        public CategoryRepository(EShopDbContext context, ILogger<CategoryRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                var categoryEntities = await _context.Categories
                    .AsNoTracking()
                    .ToListAsync();

                var categories = categoryEntities
                    .Select(c => _mapper.Map<Category>(c))
                    .ToList();

                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<Category>();
            }
        }

        public async Task<Guid> Create(Category category)
        {
            try
            {
                var chekCategory = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name == category.Name);

                if (chekCategory != null)
                    return Guid.Empty;

                var categoryEntity = _mapper.Map<CategoryEntity>(category);

                await _context.AddAsync(categoryEntity);
                await _context.SaveChangesAsync();

                return categoryEntity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Guid.Empty;
            }
        }

        public async Task<Guid> Update(Guid id, string name, string description)
        {
            try
            {
                if(!string.IsNullOrEmpty(name))
                    await _context.Categories
                        .Where(c => c.Id == id)
                        .ExecuteUpdateAsync(s => s
                        .SetProperty(c => c.Name, c => name));

                if (!string.IsNullOrEmpty(description))
                    await _context.Categories
                    .Where(c => c.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Description, c => description));

                return id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Guid.Empty;
            }
        }

        public async Task<Guid> Delete(Guid id)
        {
            try
            {
                await _context.Categories
                   .Where(c => c.Id == id)
                   .ExecuteDeleteAsync();

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Guid.Empty;
            }
        }
    }
}
