using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voyago_Backend.DTOs;
using VoyagoBackend.Services;

namespace Voyago_Backend.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUserById(Guid userId)
        {
            var user = await userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPatch("edit-my-account/{userId}")]
        [Authorize]
        public async Task<ActionResult<UserUpdateDTO>> UpdateUser(Guid userId, [FromBody] UserUpdateDTO updatedUser)
        {
            if(updatedUser == null)
            {
                return BadRequest("Invalid data.");
            }
            var user = await userService.UpdateUser(userId, updatedUser);
            return Ok(user);
        }

        [HttpDelete("delete-my-account/{userId}")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> DeleteUser(Guid userId)
        {
            var user = await userService.DeleteUser(userId);
            return Ok(user);
        }

        [HttpGet("trip/{tripId}")]
        [Authorize]
        public async Task<ActionResult<List<UserDTO>>> GetUsersInTrip(Guid tripId)
        {
            var users = await userService.GetUsersInTrip(tripId);
            return Ok(users);
        }

    }
}