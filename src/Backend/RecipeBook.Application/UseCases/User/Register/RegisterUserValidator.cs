using FluentValidation;
using RecipeBook.Communication.Requests;
using RecipeBook.Exceptions;

namespace RecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
            RuleFor(x => x.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);

        }
    }
}
