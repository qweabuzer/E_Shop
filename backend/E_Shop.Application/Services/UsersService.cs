using E_Shop.Core.Models;
using E_Shop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using E_Shop.Contracts.Contracts.Users;
using E_Shop.Contracts.Messages;

namespace E_Shop.Application.Services;

public class UsersService : IUsersService
{
	private readonly IUsersRepository _usersRepository;
	private readonly IMessagePublisher _messagePublisher;

	public UsersService(IUsersRepository usersRepository, IMessagePublisher messagePublisher)
	{
		_usersRepository = usersRepository;
		_messagePublisher = messagePublisher;
	}

	public async Task<List<Users>> GetAllUsers()
	{
		return await _usersRepository.GetAll();
	}

	public async Task<ActionResult<Guid>> CreateUser(CreateUsersRequest request)
	{
		var image = request.ProfileImage;
		if (string.IsNullOrWhiteSpace(image))
		{
			image = Users.NoImage;
		}

		var user = new Users
		{
			Name = request.Name,
			Email = request.Email,
			Login = request.Login,
			Password = request.Password,
			ProfileImage = image
		};

		var result = await _usersRepository.Create(user);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("пользователь уже существует");
		}

		var message = new UserCreatedMessage
		{
			UserId = result,
			CreatedTime = DateTime.UtcNow
		};

		await _messagePublisher.PublishMessage("user_created", message);

		return new OkObjectResult(result);
	}

	public async Task<ActionResult<Guid>> UpdateInfo(UpdateUsersRequest request, Guid id)
	{
		var result = await _usersRepository.Update(
			id,
			request.Name,
			request.Email,
			request.Login,
			request.Password,
			request.ProfileImage);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("логин или почта уже заняты");
		}

		return new OkObjectResult(result);
	}

	public async Task<Guid> Delete(Guid id)
	{
		return await _usersRepository.Delete(id);
	}
}
