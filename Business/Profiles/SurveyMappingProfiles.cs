using AutoMapper;
using Business.Dtos;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;
public class SurveyMappingProfiles : Profile
{
    public SurveyMappingProfiles()
    {
        CreateMap<Survey, CreatedSurveyResponse>()
          .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question))
          .ReverseMap();

        CreateMap<Survey, CreateSurveyRequest>()
           .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.QuestionText))
           .ReverseMap();

        CreateMap<Survey, UpdateSurveyRequest>()
        .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.QuestionText))
        .ReverseMap();
        CreateMap<Survey, UpdatedSurveyResponse>()
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.QuestionText))
            .ReverseMap();

        CreateMap<Survey, DeleteSurveyRequest>()
            .ReverseMap();
        CreateMap<Survey, DeletedSurveyResponse>()
            .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Question.Id))
            .ReverseMap();


        CreateMap<Survey, GetByIdSurveyResponse>()
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.QuestionText))
            .ReverseMap();


        CreateMap<Survey, GetListSurveyResponse>()
            .ForMember(dest => dest.ParticipationCount, opt => opt.MapFrom(src => src.Participations.Select(q => q.SurveyId).Count()))
            .ForMember(dest => dest.ParticipationCount, opt => opt.MapFrom(src => src.Participations.Count()))
            .ForMember(dest => dest.AnswerYes, opt => opt.MapFrom(src => src.Participations.Count(p => p.Answer == "Evet")))
            .ForMember(dest => dest.AnswerNo, opt => opt.MapFrom(src => src.Participations.Count(p => p.Answer == "Hayýr")));
        CreateMap<Paginate<Survey>, Paginate<GetListSurveyResponse>>();
    }
}
