using AutoMapper;
using Quiz.Application.Features.Answers.Commands.CreateAnswer;
using Quiz.Application.Features.Answers.Commands.UpdateAnswer;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using Quiz.Application.Features.Questions.Commands.CreateQuestion;
using Quiz.Application.Features.Questions.Commands.UpdateQuestion;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using Quiz.Application.Features.Quizs.Commands.CreateQuiz;
using Quiz.Application.Features.Quizs.Commands.UpdateQuiz;
using Quiz.Application.Features.Quizs.Queries.GetQuizDetail;
using Quiz.Application.Features.Quizs.Queries.GetQuizsList;
using Quiz.Application.Features.Results.Commands.CreateResult;
using Quiz.Application.Features.Results.Commands.UpdateResult;
using Quiz.Application.Features.Results.Queries.GetResultQueryList;
using Quiz.Domain.Entities;
using System.Numerics;

namespace Quiz.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz.Domain.Entities.Quiz,CreateQuizCommand>().ReverseMap();
            CreateMap<Quiz.Domain.Entities.Quiz, UpdateQuizCommand>().ReverseMap();
            CreateMap<Quaternion,CreateQuestionCommand>().ReverseMap();
            CreateMap<Quaternion,UpdateQuestionCommand>().ReverseMap();
            CreateMap<Result,CreateResultCommand>().ReverseMap();
            CreateMap<Result,UpdateResultCommand>().ReverseMap();
            CreateMap<Answer,UpdateAnswerCommand>().ReverseMap();
            CreateMap<Answer,CreateAnswerCommand>().ReverseMap();
            CreateMap<QuizListVm, Quiz.Domain.Entities.Quiz>().ReverseMap();
            CreateMap<Quiz.Domain.Entities.Quiz,QuizListVm > ().ReverseMap();
            CreateMap<Result, ResultListVm>()
                .ForMember(dest => dest.QuizName, opt => opt.MapFrom(src => src.Quiz.QuizName)).ReverseMap();
            CreateMap<Question, QuestionListVm>()
                .ForMember(dest => dest.Quizname, opt => opt.MapFrom(src => src.Quiz.QuizName)).ReverseMap();
            CreateMap<Answer, AnswerListVm>().
                ForMember(dest => dest.QuizName, opt => opt.MapFrom(src => src.question.Quiz.QuizName))
                .ForMember(dest => dest.Soal, opt => opt.MapFrom(src => src.question.question)).ReverseMap();

      



        }
    }
}
