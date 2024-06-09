using AutoMapper;
using Business.Dtos.Auths;
using Business.Dtos.Participations;
using Entities.Concretes;

namespace Business.Profiles;

public class ParticipationMappingProfiles : Profile
{
    public ParticipationMappingProfiles()
    {
        CreateMap<CreatedParticipationRequest, Participation>().ReverseMap();
        CreateMap<CreateParticipationResponse, Participation>().ReverseMap();
        CreateMap<Participation, GetSurveyResultsResponse>()
            .ForMember(dest=>dest.SurveyName, opt=>opt.MapFrom(src=>src.Survey.Name))
            .ReverseMap();
    }
}