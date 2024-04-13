namespace Zvent.Server.Domain.Entities;

public class Survey
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public required string Message { get; set; }
}