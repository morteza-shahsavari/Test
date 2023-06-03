using FluentValidation;


namespace Quiz.Application.Features.Quizs.Commands.CreateQuiz
{
    public class CreateQuizCommandValidator:AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(p=>p.QuizName).NotNull().NotEmpty().WithMessage("نام پرسشنامه رو پر کنید")
                .MaximumLength(70).MaximumLength(5).WithMessage("حداقل 6 و حداکثر 70 کاراکتر وارد کنید");
            RuleFor(p => p.BeginQuiz).NotEmpty().WithMessage("تاریخ و زمان آزمون را مشخص کنید")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(e => e).Must(BeginTimeQuizTimeNowBiger)
                .WithMessage("زمان شروع آزمون نباید از زمان الان کمتر باشد");
            RuleFor(e => e).Must(BeginTimeQuizEndQuizBiger)
                .WithMessage("زمان شروع آزمون نباید از زمان پایان آزمون بیشتر باشد");
        }

        private bool BeginTimeQuizTimeNowBiger(CreateQuizCommand command)
        {
            return command.BeginQuiz < DateTime.Now ? false : true;

        }


        private bool BeginTimeQuizEndQuizBiger(CreateQuizCommand command)
        {

            return command.EndQuiz <= command.BeginQuiz ? false : true;

        }
    }
}
