using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfUserDal : EfRepositoryBase<User, int, BaseDbContext>, IUserDal
{
    public EfUserDal(BaseDbContext context) : base(context)
    {
    }
}
