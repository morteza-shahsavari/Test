using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Commands.UpdateResult
{
    public class UpdateResultCommandValidator:AbstractValidator<UpdateResultCommand>
    {
        public UpdateResultCommandValidator()
        {
             RuleFor(p=>p.UserID).NotEmpty().WithMessage("کاربر نباید خالی باشد");
            RuleFor(p => p.QuizID).NotEmpty().WithMessage("آزمون نباید خالی باشد");
            RuleFor(p => p.TotalScore).NotEmpty().WithMessage("نتیجه آزمون نباید خالی باشد");
        }
    }
}
