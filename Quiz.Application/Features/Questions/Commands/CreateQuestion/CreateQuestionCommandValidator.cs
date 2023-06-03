using FluentValidation;

namespace Quiz.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator:AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(p => p.question).NotEmpty().NotNull().WithMessage("سوال نباید خالی باشد");
        }
    }
}
