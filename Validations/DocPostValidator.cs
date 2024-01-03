using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class DocPostValidator : AbstractValidator<DocPostDto>
    {
        public DocPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
