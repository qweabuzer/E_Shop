using E_Shop.Contracts.Contracts.Users;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Core.Interfaces;

public interface IUsersService
{
	Task<List<Users>> GetAllUsers();
	Task<ActionResult<Guid>> UpdateInfo(UpdateUsersRequest request, Guid id);
	Task<Guid> Delete(Guid id);
	Task<ActionResult<Guid>> CreateUser(CreateUsersRequest request);
}
