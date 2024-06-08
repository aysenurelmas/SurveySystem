using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfRefreshTokenDal : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenDal
{
    public EfRefreshTokenDal(BaseDbContext context) : base(context)
    {
    }
}
