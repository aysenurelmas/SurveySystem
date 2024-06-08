using Core.DataAccess.Security.Entities;

namespace Business.Abstracts;

public interface IUserOperationClaimService
{
    Task<IList<OperationClaim>> GetClaims(int id);

}