using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserOperationClaimDal : IRepository<UserOperationClaim, int>, IAsyncRepository<UserOperationClaim, int>
{
}
