using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Common;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Commands.GenerateTicket;

public class GenerateTicketHandler(IMapper mapper, ITicketRepository ticketRepository, IOptions<AppSettings> settings) : IRequestHandler<GenerateTicketCommand, GenerateTicketResponse>
{

    public async Task<GenerateTicketResponse> Handle(GenerateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = mapper.Map<Ticket>(request);

        var createdTicket = await ticketRepository.CreateTicket(ticket);





        return new GenerateTicketResponse
        {
            TicketCode = $"{settings.Value.SecretPrefix}-{createdTicket.Id}"
        };
        // emailing service or whatsapp api integration
        throw new NotImplementedException();
    }
}
