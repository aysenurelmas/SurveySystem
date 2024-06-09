using Business.Dtos;
using Business.Dtos.Participations;

namespace Business.Abstracts;

public interface IParticipationService
{
    Task<CreateParticipationResponse> Add(CreatedParticipationRequest createParticipationRequest);
    Task<GetSurveyResultsResponse> GetSurveyResults(int surveyId);
}
