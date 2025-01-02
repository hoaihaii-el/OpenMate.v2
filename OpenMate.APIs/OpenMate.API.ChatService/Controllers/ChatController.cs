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
        public async Task<IActionResult> GetMessages(int roomId)
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

        [HttpPost("user/calendar/{userId}")]
        public async Task<IActionResult> CreateUserCalendar(string userId)
        {
            await chatService.CreateUserCalendar(userId);
            return Ok();
        }

        [HttpPost("user/board/{userId}")]
        public async Task<IActionResult> CreateUserBoard(string userId)
        {
            await chatService.CreateUserBoard(userId);
            return Ok();
        }

        [HttpPost("notification/board/{userId}")]
        public async Task<IActionResult> AddBoardNotification(string userId, string content)
        {
            await chatService.AddBoardNotification(userId, content);
            return Ok();
        }

        [HttpPost("notification/calendar/{userId}")]
        public async Task<IActionResult> AddCalendarNotification(string userId, string content)
        {
            await chatService.AddCalendarNotification(userId, content);
            return Ok();
        }

        [HttpGet("messages/pinned/{roomId}")]
        public async Task<IActionResult> GetPinnedMessages(int roomId)
        {
            var messages = await chatService.GetPinnedMessages(roomId);
            return Ok(messages);
        }

        [HttpPost("file")]
        public async Task<IActionResult> UploadFile(FileDto file)
        {
            var url = await chatService.UploadFile(file);
            return Ok(url);
        }
    }
}
