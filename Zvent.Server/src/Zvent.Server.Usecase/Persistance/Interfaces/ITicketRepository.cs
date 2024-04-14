using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Persistance.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetTicket(Guid id);
    IAsyncEnumerable<Ticket> GetTickets(int page, int pageSize);
    Task<Ticket> CreateTicket(Ticket ticket);
    Task<Ticket> UpdateTicket(Ticket ticket);
    Task DeleteTicket(Guid id);
}
