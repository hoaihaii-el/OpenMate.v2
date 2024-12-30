using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Calendar;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Domain.Responses;
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

            if (eventDto.Attendees != null)
            {
                foreach (var attendeeId in eventDto.Attendees)
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

        public async Task<IEnumerable<EventRes>> GetEvents(DateTime? start, DateTime? end)
        {
            var min = start != null ? start : DateTime.MinValue;
            var max = end != null ? end : DateTime.MaxValue;

            var events = await context.Events
                .Where(e => e.Start >= min && e.End <= max)
                .ToListAsync();

            var eventRes = new List<EventRes>();
            foreach (var evt in events)
            {
                var attendeesId = await context.EventParticipants
                    .Where(a => a.EventId == evt.Id)
                    .Select(a => a.UserId)
                    .ToListAsync();

                var attendees = new List<AttendeeRes>();
                foreach (var attId in attendeesId)
                {
                    var user = await context.Users.FindAsync(attId);
                    attendees.Add(new AttendeeRes
                    {
                        ID = user!.Id,
                        Name = user.Name,
                    });
                }

                eventRes.Add(new EventRes
                {
                    ID = evt.Id,
                    Title = evt.Title,
                    Description = evt.Description,
                    StartTime = evt.Start,
                    EndTime = evt.End,
                    Location = evt.Location,
                    CreatedBy = evt.CreatedBy,
                    MeetingUrl = evt.MeetingUrl,
                    RemindBefore = evt.RemindBefore,
                    Attendees = attendees
                });
            }

            return eventRes;
        }
    }
}
