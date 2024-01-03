using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class UserCourseValidator : AbstractValidator<UserCourseDto>
    {
        public UserCourseValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
            RuleFor(x => x.UserId).NotEmpty().NotEqual(0);
        }
    }
}
