
using CSharpFunctionalExtensions;
using Electronics_shop.Core;

namespace E_Shop.Core.Interfaces
{
    public interface IAuthService
    {
        Task<Result<Users>> Authenticate(string login, string password);
        bool isAdmin(Users user);
    }
}
