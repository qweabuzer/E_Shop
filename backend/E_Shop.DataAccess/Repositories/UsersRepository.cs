using AutoMapper;
using E_Shop.Core.Models;
using E_Shop.Core.Interfaces;
using E_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace E_Shop.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EShopDbContext _context;
        private readonly ILogger<UsersRepository> _logger;
        private readonly IMapper _mapper;

        public UsersRepository(EShopDbContext context, ILogger<UsersRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Users>> GetAll()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(u => _mapper.Map<Users>(u))
                .ToList();

            return users;
        }

        public async Task<Users> Get(string login, string password)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

            if (userEntity == null)
            {
                return null;
            }

            var user = _mapper.Map<Users>(userEntity);
            return user;
        }

        public async Task<Guid> Create(Users user)
        {
            var checkUser = await _context.Users
              .FirstOrDefaultAsync(u => u.Login == user.Login);

            if (checkUser != null)
                return Guid.Empty;

            var userEntity = _mapper.Map<UserEntity>(user);

            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string email, string login, string password, string image)
        {
            if (!string.IsNullOrEmpty(name))
                await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Name, u => name));

            if (!string.IsNullOrEmpty(email))
                await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Email, u => email));

            var chekLogin = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login);

            var checkEmail = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (chekLogin != null || checkEmail != null)
                return Guid.Empty;

            else if (!string.IsNullOrEmpty(login))
            {
                await _context.Users
                    .Where(u => u.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.Login, u => login));

                await _context.Users
                  .Where(u => u.Id == id)
                  .ExecuteUpdateAsync(s => s
                  .SetProperty(u => u.Email, u => email));
            }

            if (!string.IsNullOrEmpty(password))
                await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Password, u => password));

            if (!string.IsNullOrEmpty(image))
                await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.ProfileImage, u => image));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
               .Where(u => u.Id == id)
               .ExecuteDeleteAsync();

            return id;
        }
    }
}
