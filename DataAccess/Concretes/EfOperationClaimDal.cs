using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimDal
{
    public EfOperationClaimDal(BaseDbContext context) : base(context)
    {
    }
}