
using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace E_Shop.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly EShopDbContext _context;
        private readonly ILogger<ProductsRepository> _logger;
        private readonly IMapper _mapper;

        public ProductsRepository(EShopDbContext context, ILogger<ProductsRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAll()
        {
            var productEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            var products = productEntities
                .Select(p => _mapper.Map<Product>(p))
                .ToList();

            return products;
        }

        public async Task<Guid> Create(Product product)
        {
            try
            {
                var checkProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.Name == product.Name);

                if (checkProduct != null)
                    return Guid.Empty;

                var productEntity = _mapper.Map<ProductEntity>(product);

                await _context.AddAsync(productEntity);
                await _context.SaveChangesAsync();

                return productEntity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Guid.Empty;
            }
        }

        public async Task<Guid> Update(Guid id, string name, string description, decimal price, Guid categoryId, string image, bool isAvailable)
        {
            try
            {
                var chekName = await _context.Products
                    .FirstOrDefaultAsync(p => p.Name == name);

                if (chekName != null)
                    return Guid.Empty;

                else if (!string.IsNullOrEmpty(name))
                    await _context.Products
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Name, p => name));

                if (!string.IsNullOrEmpty(description))
                    await _context.Products
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Description, p => description));

                if (price > 0)
                    await _context.Products
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Price, p => price));

                var checkCategory = await _context.Categories
                    .FirstOrDefaultAsync(p => p.Id == categoryId);

                if (checkCategory != null)
                {
                    await _context.Products
                        .Where(p => p.Id == id)
                        .ExecuteUpdateAsync(s => s
                        .SetProperty(p => p.Description, p => description));
                }

                if (!string.IsNullOrEmpty(image))
                    await _context.Products
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Image, p => image));

                await _context.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.IsAvailable, p => isAvailable));

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Guid.Empty;
            }
        }

        public async Task<Guid> Delete(Guid id)
        {
            try
            {
                await _context.Products
                   .Where(p => p.Id == id)
                   .ExecuteDeleteAsync();


                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Guid.Empty;
            }
        }
    }
}
