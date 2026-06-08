using CSharpFunctionalExtensions;
using E_Shop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using E_Shop.Contracts.Contracts.Users;

namespace E_Shop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private readonly IUsersService _usersService;
	private readonly IAuthService _authService;
	public UsersController(IUsersService usersService, IAuthService authService)
	{
		_usersService = usersService;
		_authService = authService;
	}

	[HttpGet("GetAll")]
	public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
	{
		var users = await _usersService.GetAllUsers();

		var response = users
			.Select(u => new UserResponse
			{
				Id = u.Id,
				Name = u.Name,
				Email = u.Email,
				Login = u.Login,
				Password = u.Password,
				ProfileImage = u.ProfileImage!
			});

		return Ok(response);
	}

	[HttpPost("Create")]
	public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUsersRequest request)
	{
		return await _usersService.CreateUser(request);
	}

	[HttpPatch("Update")]
	public async Task<ActionResult<Guid>> UpdateUser(Guid userId, [FromBody] UpdateUsersRequest request)
	{
		return await _usersService.UpdateInfo(request, userId);
	}

	[HttpDelete("Delete")]
	public async Task<ActionResult<Guid>> DeleteUser(Guid userId)
	{
		return await _usersService.Delete(userId);
	}
}
