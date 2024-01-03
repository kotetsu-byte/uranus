using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class HomeworkValidator : AbstractValidator<HomeworkDto>
    {
        public HomeworkValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Deadline).NotEmpty();
            RuleFor(x => x.IsDone).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
