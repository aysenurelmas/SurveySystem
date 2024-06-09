using Business.Abstracts;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Security.Entities;
using Core.DataAccess.Security.JWT;
using Core.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthOperationManager : IAuthOperationService
{
    private readonly IOperationClaimDal _operationClaimDal;
    private readonly IUserDal _userDal;
    private readonly IRefreshTokenDal _refreshTokenDal;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimDal _userOperationClaimDal;
    //private readonly TokenOptions _tokenOptions;

    public AuthOperationManager(IOperationClaimDal operationClaimDal, IUserDal userDal, IRefreshTokenDal refreshTokenDal,
        ITokenHelper tokenHelper, IUserOperationClaimDal userOperationClaimDal)
    {
        _operationClaimDal = operationClaimDal;
        _userDal = userDal;
        _refreshTokenDal = refreshTokenDal;
        _tokenHelper = tokenHelper;
        _userOperationClaimDal = userOperationClaimDal;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        var addedToken = await _refreshTokenDal.AddAsync(refreshToken);
        return addedToken;
    }

    public async Task AssignRolesToUser(int userId, List<int> roleIds)
    {
        User user = await _userDal.GetAsync(i => i.Id == userId);
        if (user == null)
            throw new BusinessException("Kullanıcı bulunamadı.");

        List<UserOperationClaim> claims = new List<UserOperationClaim>();
        foreach (int id in roleIds)
        {
            OperationClaim role = await _operationClaimDal.GetAsync(i => i.Id == id);
            if (role != null)
            {
                UserOperationClaim claim = new UserOperationClaim(userId, id);
                claims.Add(claim);
            }
        }

        await _userOperationClaimDal.AddRangeAsync(claims);
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {

        IList<OperationClaim> userRoles = await _userOperationClaimDal
            .Query()
            .Where(i => i.UserId == user.Id && !i.DeletedDate.HasValue)
            //.Include(i=>i.OperationClaim)
            .Select(i => new OperationClaim() { Id = i.OperationClaimId, Name = i.OperationClaim.Name })
            .ToListAsync();

        AccessToken accessToken = _tokenHelper.CreateToken(user, userRoles);
        return accessToken;
    }

    // Add işlemini farklı fonksiyona taşıma
    // RefreshTokenDto
    public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);

        return refreshToken;
    }

    public async Task<RefreshToken> GetRefreshToken(string token)
    {
        RefreshToken refreshToken = await _refreshTokenDal.GetAsync(i => i.Token == token);
        return refreshToken;
    }

    public async Task RemoveAllRolesFromUser(int userId)
    {
        var operationClaims = _userOperationClaimDal.Query().Where(i => i.UserId == userId).ToList();

        await _userOperationClaimDal.DeleteRangeAsync(operationClaims);
    }

}
