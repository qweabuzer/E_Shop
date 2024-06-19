
using CSharpFunctionalExtensions;
using Electronics_shop.Core;

namespace E_Shop.Core.Interfaces
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllUsers();
        Task<Result<Guid>> CreateUser(Users user);
        Task<Result<Guid>> UpdateInfo(Guid id, string name, string email, string login, string password, string image);
        Task<Guid> Delete(Guid id);
    }
}
