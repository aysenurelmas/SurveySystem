using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimDal
{
    public EfUserOperationClaimDal(BaseDbContext context) : base(context)
    {
    }
}
