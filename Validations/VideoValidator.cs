using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class VideoValidator : AbstractValidator<VideoDto>
    {
        public VideoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
        }
    }
}
