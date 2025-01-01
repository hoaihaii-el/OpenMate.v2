using Microsoft.AspNetCore.Mvc;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Interfaces;

namespace OpenMate.API.CalendarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController(ICalendarService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(DateTime? start, DateTime? end)
        {
            return Ok(await service.GetEvents(start, end));
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto eventDto)
        {
            await service.AddEvent(eventDto);
            return Ok("Done");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventDto eventDto)
        {
            await service.UpdateEvent(id, eventDto);
            return Ok("Done");
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> Delete(int eventId)
        {
            await service.DeleteEvent(eventId);
            return Ok("Done");
        }

        [HttpDelete("{eventId}/attendee/{userId}")]
        public async Task<IActionResult> DeleteAttendee(int eventId, string userId)
        {
            await service.DeleteAttendee(eventId, userId);
            return Ok("Done");
        }

        [HttpGet("suggestion")]
        public async Task<IActionResult> GetSuggestion(string? att)
        {
            return Ok(await service.GetSuggestion(att));
        }
    }
}
