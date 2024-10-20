using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet("rooms-by-userId/{userId}")]
        public async Task<ActionResult> GetRooms(string userId)
        {
            return Ok();
        }

        [HttpGet("room-detail/{roomId}")]
        public async Task<ActionResult> GetRoom(int roomId)
        {
            return Ok();
        }

        [HttpPost("new-room")]
        public async Task<ActionResult> NewRoom()
        {
            return Ok();
        }

        [HttpPost("room-add-participant")]
        public async Task<ActionResult> AddParticipant()
        {
            return Ok();
        }

        [HttpDelete("room-remove-participant")]
        public async Task<ActionResult> RemoveParticipant()
        {
            return Ok();
        }

        [HttpGet("room-messages/{roomId}")]
        public async Task<ActionResult> GetMessages(int roomId)
        {
            return Ok();
        }

        [HttpPost("new-message")]
        public async Task<ActionResult> NewMessage()
        {
            return Ok();
        }

        [HttpPut("edit-message")]
        public async Task<ActionResult> EditMessage()
        {
            return Ok();
        }

        [HttpGet("message-medias/{msgId}")]
        public async Task<ActionResult> GetMedias(int msgId)
        {
            return Ok();
        }

        [HttpGet("message-reactions/{msgId}")]
        public async Task<ActionResult> GetReactions(int msgId)
        {
            return Ok();
        }

        [HttpPut("add-reaction/{msgId}")]
        public async Task<ActionResult> AddReaction(int msgId)
        {
            return Ok();
        }

        [HttpPut("remove-reaction/{msgId}")]
        public async Task<ActionResult> RemoveReaction(int msgId)
        {
            return Ok();
        }
    }
}
