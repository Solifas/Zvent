using Zvent.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Zvent.Server.Usecase.Persistance.Interfaces;
using Zvent.Server.Infrastructure.Persistance.Contexts;

namespace Zvent.Server.Infrastructure.Persistance.Repositories;

public class TicketRepository : ITicketRepository
{
    public Task<Ticket> CreateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTicket(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket?> GetTicket(Guid id)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Ticket> GetTickets(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> UpdateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
