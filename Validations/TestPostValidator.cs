using FluentValidation;
using Uranus.Dto;

namespace Uranus.Validations
{
    public class TestPostValidator : AbstractValidator<TestPostDto>
    {
        public TestPostValidator()
        {
            RuleFor(x => x.Question).NotEmpty();
            RuleFor(x => x.Answer1).NotEmpty();
            RuleFor(x => x.Answer2).NotEmpty();
            RuleFor(x => x.Answer3).NotEmpty();
            RuleFor(x => x.Answer4).NotEmpty();
            RuleFor(x => x.CorrectAnswer).NotEmpty();
            RuleFor(x => x.Points).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
