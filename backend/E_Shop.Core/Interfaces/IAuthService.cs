
using CSharpFunctionalExtensions;
using E_Shop.Core.Models;

namespace E_Shop.Core.Interfaces
{
    public interface IAuthService
    {
        Task<Result<Users>> Authenticate(string login, string password);
        bool isAdmin(Users user);
    }
}
