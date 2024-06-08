using Core.DataAccess.Repositories;

namespace Entities.Concretes;

public class Survey : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Question> Questions { get; set; }
    public virtual ICollection<Participation> Participations { get; set; }
}