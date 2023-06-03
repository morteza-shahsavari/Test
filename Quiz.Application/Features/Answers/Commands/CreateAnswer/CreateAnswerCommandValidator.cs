using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandValidator:AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator()
        {
            RuleFor(p=>p.ResultID).NotEmpty().WithMessage("پاسخنامه باید پر شود");
            RuleFor(p=>p.QuestionID).NotEmpty().WithMessage("سوال باید پر شود");

        }
    }
}
