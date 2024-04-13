using Zvent.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Zvent.Server.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
