using MediatR;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Queries.GetEvents;

public class GetEventsQueryHandler(IEventsRepository eventRepository) : IRequestHandler<GetEventsQuery, GetEventsQueryResponse>
{
    private readonly IEventsRepository _eventRepository = eventRepository;

    public async Task<GetEventsQueryResponse> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {

        var events = await _eventRepository.GetEvents(request.Page, request.PageSize);

        return new GetEventsQueryResponse
        {
            TotalCount = events.Count(),
            Events = events.ToList()
        };
    }
}

