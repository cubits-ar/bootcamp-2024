using Bootcamp.Domain.Interfaces;
using MediatR;

namespace Bootcamp.Application.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId);

        if (user is null)
            return;

        user.Name = request.Name;

        await _userRepository.Update(user);
    }
}