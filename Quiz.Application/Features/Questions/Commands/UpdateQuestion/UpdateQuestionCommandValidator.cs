using FluentValidation;


namespace Quiz.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(p => p.question).NotEmpty().NotNull().WithMessage("سوال نباید خالی باشد");
        }
    }
}
