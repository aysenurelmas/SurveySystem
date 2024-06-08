using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;

namespace DataAccess.Abstracts;

public interface IOperationClaimDal : IRepository<OperationClaim, int>, IAsyncRepository<OperationClaim, int>
{
}
