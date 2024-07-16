using Bootcamp.Application.Models;
using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Queries.GetUserList;

public class GetUserListHandler : IRequestHandler<GetUserListQuery, GetUserListResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserListHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserListResponse> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var response = new GetUserListResponse();

        var userList = await _userRepository.GetList();

        response.UserList = userList
            .OrderByDescending(user => user.Id)
            .Select(user => new UserDto { Id = user.Id, Name = user.Name })
            .ToList();

        return response;
    }
}