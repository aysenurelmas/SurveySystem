using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Application.Features.Surveys.Rules;

public class SurveyBusinessRules : BaseBusinessRules
{
    private readonly ISurveyDal _surveyDal;

    public SurveyBusinessRules(ISurveyDal surveyDal)
    {
        _surveyDal = surveyDal;
    }


    public async Task SurveyShouldExistWhenSelected(Survey? survey)
    {
        if (survey == null)
             throw new BusinessException(BusinessMessages.SurveyNotFound);
    }

    public async Task SurveyIdShouldExistWhenSelected(int id)
    {
        Survey? survey = await _surveyDal.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false
            );
        await SurveyShouldExistWhenSelected(survey);
    }
}