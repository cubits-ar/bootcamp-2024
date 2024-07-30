using Bootcamp.Domain.Entities;
using Bootcamp.Domain.Enums;
using Bootcamp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Bootcamp.Application.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository, 
        IValidator<CreateUserCommand> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(request);

        var user = new User { Name = request.Name, RoleId = (int)RoleEnum.Admin };
        await _userRepository.Create(user);
    }
}