using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfParticipationDal : EfRepositoryBase<Participation, int, BaseDbContext>, IParticipationDal
{
    public EfParticipationDal(BaseDbContext context) : base(context)
    {
    }
}