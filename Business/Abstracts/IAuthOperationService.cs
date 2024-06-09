using Core.DataAccess.Security.Entities;
using Core.DataAccess.Security.JWT;

namespace Business.Abstracts;

public interface IAuthOperationService
{
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    public Task<RefreshToken> GetRefreshToken(string token);
}