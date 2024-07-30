using Bootcamp.Application.Commands.CreateUser;
using FluentValidation;

namespace Bootcamp.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre no puede ser vacio.");

            RuleFor(x => x.Name)
                .MinimumLength(5)
                .WithMessage("El nombre debe tener 5 caracteres minimo.");
        }
    }
}
