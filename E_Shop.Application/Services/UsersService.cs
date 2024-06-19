using CSharpFunctionalExtensions;
using E_Shop.Core.Interfaces;
using Electronics_shop.Core;

namespace E_Shop.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _usersRepository.GetAll();
        }

        public async Task<Result<Guid>> CreateUser(Users user)
        {
            return await _usersRepository.Create(user);
        }

        public async Task<Result<Guid>> UpdateInfo(Guid id, string name, string email, string login, string password, string image)
        {
            return await _usersRepository.Update(id, name, email, login, password, image);
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            return await _usersRepository.Delete(id);
        }
    }
}
