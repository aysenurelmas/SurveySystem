namespace Business.Dtos.Participations;

public class CreateParticipationResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public string Answer { get; set; }
}
