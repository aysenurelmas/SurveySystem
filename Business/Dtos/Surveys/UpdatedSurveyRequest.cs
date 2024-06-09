namespace Business.Dtos;

public class UpdateSurveyRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string QuestionText { get; set; }
}
