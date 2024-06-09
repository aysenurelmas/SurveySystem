using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Participations;

public class GetSurveyResultsResponse
{
    public string SurveyName { get; set; }
    public int ParticipationCount { get; set; }
    public int AnswerNo { get; set; }
    public int AnswerYes { get; set; }
}
