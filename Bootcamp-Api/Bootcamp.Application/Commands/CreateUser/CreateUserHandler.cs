using Bootcamp.Domain.Entities;
using Bootcamp.Domain.Enums;
using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User { Name = request.Name, RoleId = (int)RoleEnum.Admin };
        await _userRepository.Create(user);
    }
}