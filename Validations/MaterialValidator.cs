using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class MaterialValidator : AbstractValidator<MaterialDto>
    {
        public MaterialValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.HomeworkId).NotEmpty().NotEqual(0);
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
