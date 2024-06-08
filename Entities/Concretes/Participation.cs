using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;

namespace Entities.Concretes;

public class Participation : Entity<int>
{
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public string Answer { get; set; }

    public virtual Survey Survey { get; set; }
    public virtual User User {  get; set; }
}

