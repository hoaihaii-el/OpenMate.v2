using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.Entities;
using OpenMate.API.Domain.Entities.Board;
using OpenMate.API.Domain.Entities.Calendar;
using OpenMate.API.Domain.Entities.Chat;

namespace OpenMate.API.Infrastructure.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EventOM> Events { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<TaskOM> Tasks { get; set; }
        public DbSet<TaskDescription> TaskDescriptions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
