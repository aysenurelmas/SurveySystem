using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;

namespace DataAccess.Abstracts;

public interface IRefreshTokenDal : IRepository<RefreshToken, int>, IAsyncRepository<RefreshToken, int>
{
}
