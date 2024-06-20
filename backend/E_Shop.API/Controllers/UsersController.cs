using CSharpFunctionalExtensions;
using E_Shop.API.Contracts;
using E_Shop.Core.Interfaces;
using Electronics_shop.Core;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers
{
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
                .Select(u => new UserResponse(
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Login,
                    u.Password,
                    u.ProfileImage
                    ));

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {
            var user = Users.Create(
                Guid.NewGuid(),
                request.Name,
                request.Email,
                request.Login,
                request.Password,
                request.ProfileImage
                );

            if (user.IsFailure)
                return BadRequest(user.Error);

            var userId = await _usersService.CreateUser(user.Value);

            if (userId.IsFailure)
                return BadRequest(userId.Error);

            return Ok(userId.Value);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid userId, [FromBody] UsersRequest request)
        {
            var result = await _usersService.UpdateInfo(
                userId,
                request.Name,
                request.Email,
                request.Login,
                request.Password,
                request.ProfileImage);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(userId);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid userId)
        {
            return Ok(await _usersService.Delete(userId));
        }
    }
}
