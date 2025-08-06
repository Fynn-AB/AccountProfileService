using AccountProfileService.DTOs;
using Azure.Core;
using Data.Entities;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountProfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;


        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var user = new UserEntity 
            { 
                UserName = userDto.UserName, 
                Email = userDto.Email, 
                PhoneNumber = userDto.Phone 
            };

            var result = await _userService.CreateUserAsync(user, userDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok("User created successfully.");
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var userById = await _userService.GetUserByIdAsync(userId);

            if (userById == null)
                return NotFound("User not found.");

            var user = new GetUserDto
            {
                Id = userById.Id!,
                UserName = userById.UserName!,
                Email = userById.Email!,
                PhoneNumber = userById.PhoneNumber
            };

            return Ok(user);
        }


        [HttpGet("by-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery]string email)
        {
            var userById = await _userService.GetUserByEmailAsync(email);

            if (userById == null)
                return NotFound("User not found.");

            var user = new GetUserDto
            {
                Id = userById.Id!,
                UserName = userById.UserName!,
                Email = userById.Email!,
                PhoneNumber = userById.PhoneNumber
            };

            return Ok(user);
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            if (users == null || users.Count == 0)
                return NotFound("No users found.");

            var userDtos = users.Select(user => new GetUserDto
            {
                Id = user.Id!,
                Email = user.Email!,
                UserName = user.UserName!,
                PhoneNumber = user.PhoneNumber
            }).ToList();

            return Ok(userDtos);
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto updatedDto)
        {
            var user = await _userService.GetUserByIdAsync(updatedDto.UserId);
            if (user == null)
                return NotFound("No user with that id");

            user.UserName = updatedDto.UserName;
            user.Email = updatedDto.Email;
            user.PhoneNumber = updatedDto.PhoneNumber;

            var result = await _userService.UpdateUserAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok(new GetUserDto
            {
                Id = user.Id!,
                UserName = user.UserName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber
            });
        }


        [HttpPut("change-password")]
        public async Task<IActionResult> UpdatePassword(PasswordChangeDto passwordDto)
        {
            if (passwordDto == null)
                return BadRequest("Invalid password data.");

            var result = await _userService.UpdatePasswordAsync(
                passwordDto.UserId, 
                passwordDto.CurrentPassword, 
                passwordDto.NewPassword
            );

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok("Password updated successfully.");
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound("User not found.");

            var result = await _userService.DeleteUserAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok("User deleted successfully.");
        }
    }
}
