using AutoMapper;
using Bootcamp.Application.Models;
using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Queries.GetUser;

public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var response = new GetUserResponse();

        var user = await _userRepository.Get(request.UserId);

        if (user is null)
            return response;

        response.User = _mapper.Map<UserDto>(user);

        return response;
    }
}