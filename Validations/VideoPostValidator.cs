using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class VideoPostValidator : AbstractValidator<VideoPostDto>
    {
        public VideoPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
        }
    }
}
