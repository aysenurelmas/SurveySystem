namespace Business.Dtos.Participations;

public class CreatedParticipationRequest
{
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public string Answer { get; set; }
}