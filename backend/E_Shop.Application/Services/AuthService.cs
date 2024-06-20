using CSharpFunctionalExtensions;
using E_Shop.Core.Models;
using E_Shop.Core.Interfaces;

namespace E_Shop.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<Result<Users>> Authenticate(string login, string password)
        {
            var user = await _usersRepository.Get(login, password);
            if (user == null)
            {
                return Result.Failure<Users>("Неверный логин или пароль");
            }

            return Result.Success(user);
        }

        //TO DO
        public bool isAdmin(Users user)
        {
            return true;
        }
    }
}
