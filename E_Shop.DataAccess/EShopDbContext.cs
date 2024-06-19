using E_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.DataAccess
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
