using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Calendar;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class CalendarService(DataContext context) : ICalendarService
    {
        public async Task AddEvent(EventDto eventDto)
        {
            var newEvent = new EventOM
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                Location = eventDto.Location,
                CreatedBy = eventDto.CreatedBy,
                CreatedAt = DateTime.Now,
                MeetingUrl = eventDto.MeetingUrl,
                RemindBefore = eventDto.RemindBefore
            };

            context.Events.Add(newEvent);
            await context.SaveChangesAsync();

            if (eventDto.AttendeesId != null)
            {
                foreach (var attendeeId in eventDto.AttendeesId)
                {
                    var newAttendee = new EventParticipants
                    {
                        EventId = newEvent.Id,
                        UserId = attendeeId
                    };

                    context.EventParticipants.Add(newAttendee);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAttendee(int eventId, string userId)
        {
            var attendee = await context.EventParticipants.FindAsync(eventId, userId);
            if (attendee != null)
            {
                context.EventParticipants.Remove(attendee);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEvent(int id)
        {
            var evt = await context.Events.FindAsync(id);
            if (evt != null)
            {
                context.Events.Remove(evt);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventDto>> GetEvents(DateTime? start, DateTime? end)
        {
            var min = start != null ? start : DateTime.MinValue;
            var max = end != null ? end : DateTime.MaxValue;

            return await context.Events.Where(e => e.Start >= min && e.End <= max)
                .Select(e => new EventDto
                {
                    Title = e.Title,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Location = e.Location,
                    CreatedBy = e.CreatedBy,
                    MeetingUrl = e.MeetingUrl,
                    RemindBefore = e.RemindBefore,
                    AttendeesId = context.EventParticipants
                        .Where(ep => ep.EventId == e.Id)
                        .Select(ep => ep.UserId)
                        .ToList()
                }).ToListAsync();
        }
    }
}
