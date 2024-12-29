using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.Entities;
using OpenMate.API.Domain.Entities.Calendar;

namespace OpenMate.API.Infrastructure.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EventOM> Events { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
    }
}
