namespace Zvent.Server.Domain.Entities;

public class Event
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int NumberOfTickets { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
