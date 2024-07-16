using Bootcamp.Application.Models;
using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Queries.GetUser;

public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var response = new GetUserResponse();

        var user = await _userRepository.Get(request.UserId);

        if (user is null)
            return response;

        response.User = new UserDto { Id = user.Id, Name = user.Name };

        return response;
    }
}