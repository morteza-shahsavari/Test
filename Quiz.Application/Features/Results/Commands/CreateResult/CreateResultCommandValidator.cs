using FluentValidation;
namespace Quiz.Application.Features.Results.Commands.CreateResult
{
    public class CreateResultCommandValidator:AbstractValidator<CreateResultCommand>
    {
        public CreateResultCommandValidator()
        {
            RuleFor(p=>p.UserID).NotEmpty().WithMessage("کاربر نباید خالی باشد");
            RuleFor(p => p.QuizID).NotEmpty().WithMessage("آزمون نباید خالی باشد");
        }
    }
}
