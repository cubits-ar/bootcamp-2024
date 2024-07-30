using Bogus;
using Bootcamp.Application.Commands.CreateUser;
using Bootcamp.Domain.Entities;
using Bootcamp.Domain.Interfaces;
using FluentValidation;
using NSubstitute;

namespace Bootcamp.Application.Tests
{
    public class CreateUserHandlerTests
    {
        private readonly CreateUserHandler _sut;
        private readonly IUserRepository _userRepository;

        public CreateUserHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            var validator = Substitute.For<IValidator<CreateUserCommand>>();

            _sut = new CreateUserHandler(_userRepository, validator);
        }

        [Fact]
        public  async Task CreateUserHandler_ReturnsNoError_WhenRequestIsValid()
        {
            // arrange
            // var command = new CreateUserCommand { Name = "Tomas" };

            var command = new Faker<CreateUserCommand>()
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .Generate();

            _userRepository.Create(Arg.Any<User>()).Returns(1);

            // act
            await _sut.Handle(command, CancellationToken.None);

            // assert
        }

        [Fact]
        public async Task CreateUserHandler_ReturnsException_WhenRequestIsInvalid()
        {
            // arrange
            var command = new CreateUserCommand();
            _userRepository.Create(Arg.Any<User>()).Returns(0);

            // act
            await Assert.ThrowsAsync<Exception>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}