using AutoMapper;
using Azure;
using Azure.Core;
using Business.Abstracts;
using Business.Dtos.Participations;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ParticipationManager : IParticipationService
{
    private readonly IParticipationDal _participationDal;
    private readonly IMapper _mapper;
    private readonly ParticipationRules _participationRules;

    public ParticipationManager(IParticipationDal participationDal, IMapper mapper, ParticipationRules participationRules)
    {
        _participationDal = participationDal;
        _mapper = mapper;
        _participationRules = participationRules;
    }

    public async Task<CreateParticipationResponse> Add(CreatedParticipationRequest createParticipationRequest)
    {
       await _participationRules.HasUserParticipatedAsync(createParticipationRequest.SurveyId, createParticipationRequest.UserId);
        Participation participation = _mapper.Map<Participation>(createParticipationRequest);
        await _participationDal.AddAsync(participation);
        CreateParticipationResponse createParticipationResponse = _mapper.Map<CreateParticipationResponse>(participation);
        return createParticipationResponse;
    }

    public async Task<GetSurveyResultsResponse> GetSurveyResults(int surveyId)
    {
        var participations = await _participationDal.GetListAsync(p=>p.SurveyId == surveyId);
        
        int countYes = participations.Items.Count(predicate: p => p.Answer == "Evet");
        var countNo = participations.Items.Count(predicate: p => p.Answer == "Hayır");
        GetSurveyResultsResponse getSurveyResultsResponse = new GetSurveyResultsResponse
        {
            ParticipationCount = participations.Count,
            AnswerYes = countYes,
            AnswerNo = countNo
        };
        return getSurveyResultsResponse;        
    }
}
