using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.Entities;

namespace OpenMate.API.Infrastructure.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
