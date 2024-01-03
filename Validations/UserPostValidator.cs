using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class UserPostValidator : AbstractValidator<UserPostDto>
    {
        public UserPostValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
