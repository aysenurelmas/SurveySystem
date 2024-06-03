using Core.Entities;

namespace Entities.Concretes;

public class Participation : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
    public string Answer { get; set; }
}

