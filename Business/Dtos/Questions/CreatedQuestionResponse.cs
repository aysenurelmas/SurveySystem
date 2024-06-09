namespace Business.Dtos.Questions;

public class CreatedQuestionResponse
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public string QuestionText { get; set; }
}
