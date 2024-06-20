using CSharpFunctionalExtensions;
using E_Shop.Core.Models;
using E_Shop.Core.Interfaces;

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
            var result = await _usersRepository.Create(user);
            if (result == Guid.Empty)
                return Result.Failure<Guid>("Пользователь уже существует");

            return Result.Success<Guid>(result);
        }

        public async Task<Result<Guid>> UpdateInfo(Guid id, string name, string email, string login, string password, string image)
        {
            var result = await _usersRepository.Update(id, name, email, login, password, image);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Логин или почта уже заняты");

            return Result.Success<Guid>(result);
        }

        public async Task<Guid> Delete(Guid id)
        {
            return await _usersRepository.Delete(id);
        }
    }
}
