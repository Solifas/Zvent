using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Persistance.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetTicket(Guid id);
    IAsyncEnumerable<Ticket> GetTickets(int page, int pageSize);
    Task<Guid> CreateTicket(Ticket ticket);
    Task<bool> UpdateTicket(Ticket ticket);
    Task DeleteTicket(Guid id);
}
