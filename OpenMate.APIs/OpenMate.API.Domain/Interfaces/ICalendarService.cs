using OpenMate.API.Domain.DTOs;

namespace OpenMate.API.Domain.Interfaces
{
    public interface ICalendarService
    {
        Task AddEvent(EventDto eventDto);
        Task DeleteEvent(int id);
        Task DeleteAttendee(int eventId, string userId);
        Task<IEnumerable<EventDto>> GetEvents(DateTime? start, DateTime? end);
    }
}
