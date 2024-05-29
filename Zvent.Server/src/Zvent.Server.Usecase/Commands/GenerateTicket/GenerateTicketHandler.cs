using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Common;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Commands.GenerateTicket;

public class GenerateTicketHandler(IMapper mapper, ITicketRepository ticketRepository,
 IOptions<AppSettings> settings, IEventsRepository eventsRepository) : IRequestHandler<GenerateTicketCommand, GenerateTicketResponse>
{

    public async Task<GenerateTicketResponse> Handle(GenerateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = mapper.Map<Ticket>(request);
        var createdTicketId = await ticketRepository.CreateTicket(ticket);
        var selectedEvent = await eventsRepository.GetEvent(request.EventId);
        selectedEvent.NumberOfTickets--;

        if (selectedEvent.NumberOfTickets < 0)
        {
            return new GenerateTicketResponse
            {
                ErrorMessage = "No more tickets available"
            };
        }

        await eventsRepository.UpdateEvent(selectedEvent);

        return new GenerateTicketResponse
        {
            TicketCode = $"{settings.Value.SecretPrefix}-{createdTicketId}"
        };
        // emailing service or whatsapp api integration
    }
}
