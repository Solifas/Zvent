using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Persistance.Interfaces;

public interface IEventsRepository
{
    Task<Event?> GetEvent(Guid id);
    Task<IEnumerable<Event>> GetEvents(int page, int pageSize);
    Task<bool> CreateEvent(Event @event);
    Task<bool> UpdateEvent(Event @event);
    Task DeleteEvent(Guid id);
}