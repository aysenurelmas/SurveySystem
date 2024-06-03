using Core.Entities;

namespace Entities.Concretes;

public class Survey : Entity<Guid>
{
    public string Name { get; set; }
}