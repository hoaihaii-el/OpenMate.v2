using Microsoft.AspNetCore.Mvc;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Interfaces;

namespace OpenMate.API.ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Chat service is running");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll(string? query)
        {
            var users = await userService.GetAll(query);
            return Ok(users);
        }
    }
}
