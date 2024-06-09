using Business.Dtos.Participations;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class ParticipationRules : BaseBusinessRules
{
    IParticipationDal _participationDal;

    public ParticipationRules(IParticipationDal participationDal)
    {
        _participationDal = participationDal;
    }

    public async Task HasUserParticipatedAsync(int surveyId, int userId)
    {
        var participations = await _participationDal.GetListAsync(p => p.SurveyId == surveyId);
        var alreadyParticipated = participations.Items.Any(p => p.UserId == userId);
        if (alreadyParticipated)
        {
            throw new BusinessException(BusinessMessages.HasUserParticipatedAsync);
        }
    }
}
