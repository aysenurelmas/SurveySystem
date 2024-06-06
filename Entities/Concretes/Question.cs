using Core.DataAccess.Repositories;

namespace Entities.Concretes;

public class Question : Entity<Guid>
{
    public Guid SurveyId { get; set; }
    public string QuestionText { get; set; }

    public virtual Survey Survey { get; set; }
}

