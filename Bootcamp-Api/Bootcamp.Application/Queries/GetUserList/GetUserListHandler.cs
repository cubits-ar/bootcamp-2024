using AutoMapper;
using Bootcamp.Application.Models;
using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Queries.GetUserList;

public class GetUserListHandler : IRequestHandler<GetUserListQuery, GetUserListResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserListHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserListResponse> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var response = new GetUserListResponse();

        var userList = await _userRepository.GetList();

        response.UserList = userList
            .OrderByDescending(user => user.Id)
            .Select(user => _mapper.Map<UserDto>(user))
            .ToList();

        return response;
    }
}