using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class CoursePostValidator : AbstractValidator<CoursePostDto>
    {
        public CoursePostValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
