using Microsoft.AspNetCore.Mvc;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Interfaces;

namespace OpenMate.API.ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IChatService chatService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Chat service is running");
        }

        [HttpGet("rooms/{userId}")]
        public async Task<IActionResult> GetRooms(string userId)
        {
            var rooms = await chatService.GetRooms(userId);
            return Ok(rooms);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetRoom(int roomId)
        {
            var room = await chatService.GetRoom(roomId);
            return Ok(room);
        }

        [HttpPost("room")]
        public async Task<IActionResult> CreateRoom(RoomDto room)
        {
            await chatService.CreateRoom(room);
            return Ok();
        }

        [HttpGet("messages/{roomId}")]
        public async Task<IActionResult> GetMessages(string roomId)
        {
            var messages = await chatService.GetMessages(roomId);
            return Ok(messages);
        }

        [HttpPost("message")]
        public async Task<IActionResult> CreateMessage(MessageDto message)
        {
            await chatService.CreateMessage(message);
            return Ok();
        }

        [HttpPost("message/pin/{messageId}")]
        public async Task<IActionResult> PinMessage(string messageId)
        {
            await chatService.PinMessage(messageId);
            return Ok();
        }

        [HttpPost("message/read/{messageId}")]
        public async Task<IActionResult> ReadMessage(string messageId)
        {
            await chatService.ReadMessage(messageId);
            return Ok();
        }
    }
}
