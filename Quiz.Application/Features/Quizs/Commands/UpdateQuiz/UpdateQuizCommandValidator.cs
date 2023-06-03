using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.UpdateQuiz
{
    public class UpdateQuizCommandValidator:AbstractValidator<UpdateQuizCommand>
    {
        public UpdateQuizCommandValidator()
        {
            RuleFor(p=>p.QuizName).NotEmpty().WithMessage("نام پرسشنامه نباید خالی باشد");
            RuleFor(p => p.BeginQuiz).NotEmpty().WithMessage("تاریخ و زمان آزمون را مشخص کنید")
            .NotNull().GreaterThan(DateTime.Now);
            RuleFor(e => e).Must(BeginTimeQuizTimeNowBiger)
                .WithMessage("زمان شروع آزمون نباید از زمان الان کمتر باشد");
            RuleFor(e => e).Must(BeginTimeQuizEndQuizBiger)
                .WithMessage("زمان شروع آزمون نباید از زمان پایان آزمون بیشتر باشد");
        }
        private bool BeginTimeQuizTimeNowBiger(UpdateQuizCommand command)
        {
         return command.BeginQuiz < DateTime.Now?false : true;

        }
          private bool BeginTimeQuizEndQuizBiger(UpdateQuizCommand command)
        {

            return command.EndQuiz<=command.BeginQuiz?false:true;

        }
    }
}
