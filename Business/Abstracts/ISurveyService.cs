using Business.Dtos;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISurveyService
{
    Task<CreatedSurveyResponse> Add(CreateSurveyRequest createSurveyRequest);
    Task<UpdatedSurveyResponse> Update(UpdateSurveyRequest updateSurveyRequest);
    Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest);
    //Task<GetByIdSurveyResponse> GetById(GetByIdSurveyRequest getByIdSurveyRequest);
    Task<GetByIdSurveyResponse> GetSurveyDetailsById(int surveyId);
    Task<IPaginate<GetListSurveyResponse>> GetList(PageRequest pageRequest);
    Task<SurveyResultResponse> ParticipateInSurvey(int surveyId);
}
