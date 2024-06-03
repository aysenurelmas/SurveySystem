using Core.Entities;

namespace Entities.Concretes;

public class Question : Entity<Guid>
{
    public Guid SurveyId { get; set; }
    public string QuestionText { get; set; }
}

