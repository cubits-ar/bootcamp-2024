using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Commands.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId);

        if (user is null)
            return;

        await _userRepository.Delete(user);
    }
}