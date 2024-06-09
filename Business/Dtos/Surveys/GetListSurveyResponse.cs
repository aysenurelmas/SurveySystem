namespace Business.Dtos;

public class GetListSurveyResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ParticipationCount { get; set; }
    public int AnswerNo { get; set; }
    public int AnswerYes { get; set; }
}
