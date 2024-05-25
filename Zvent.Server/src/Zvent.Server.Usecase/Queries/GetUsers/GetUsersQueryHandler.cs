using MediatR;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Queries.GetUsers;

public class GetUsersQueryHandler(IUserRepository usersRepository) : IRequestHandler<GetUsersQuery, GetUsersQueryResponse>
{

    public async Task<GetUsersQueryResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await usersRepository.GetUsers(request.Page, request.PageSize);

        return new GetUsersQueryResponse
        {
            TotalCount = users.Count(),
            Users = users.ToList()
        };
    }
}
