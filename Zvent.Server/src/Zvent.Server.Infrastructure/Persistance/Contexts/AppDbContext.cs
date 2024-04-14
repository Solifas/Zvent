using Zvent.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Zvent.Server.Infrastructure.Persistance.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}