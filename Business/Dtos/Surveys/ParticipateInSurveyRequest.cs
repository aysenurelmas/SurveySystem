namespace Business.Dtos;

public class SurveyResultRequest
{
    public int SurveyId { get; set; }
    public int UserId { get; set; }
    public string Answer { get; set; }
}
