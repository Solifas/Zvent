using MediatR;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Queries.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserQuery, GetUserQueryResponse>
{
    public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var validation = new GetUserQueryValidator().Validate(request);

        if (!validation.IsValid)
        {
            var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errors);
            throw new ValidationException(errorMessage);
        }

        var user = await userRepository.GetUser(request.UserName);
        return mapper.Map<GetUserQueryResponse>(user);
    }
}
