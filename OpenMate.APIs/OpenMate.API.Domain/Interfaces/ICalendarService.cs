using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.Interfaces
{
    public interface ICalendarService
    {
        Task AddEvent(EventDto eventDto);
        Task DeleteEvent(int id);
        Task DeleteAttendee(int eventId, string userId);
        Task<IEnumerable<EventRes>> GetEvents(DateTime? start, DateTime? end);
        Task UpdateEvent(int id, EventDto eventDto);
        Task<IEnumerable<AttendeeRes>> GetSuggestion(string? att);
    }
}
