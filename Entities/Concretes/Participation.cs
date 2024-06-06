using Core.DataAccess.Repositories;

namespace Entities.Concretes;

public class Participation : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
    public string Answer { get; set; }

    public virtual Survey Survey { get; set; }
}

