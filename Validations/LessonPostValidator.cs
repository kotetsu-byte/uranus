using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class LessonPostValidator : AbstractValidator<LessonPostDto>
    {
        public LessonPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Info).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
