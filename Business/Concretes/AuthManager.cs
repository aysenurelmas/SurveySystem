using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Auths;
using Business.Rules;
using Core.DataAccess.Security.Entities;
using Core.DataAccess.Security.Hashing;
using Core.DataAccess.Security.JWT;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;

    public AuthManager(IUserService userService, AuthBusinessRules authBusinessRules, IMapper mapper, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
    {
        _userService = userService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {

        User? userToLogin = await _userService.GetByEmail(loginRequest.Email);

        await _authBusinessRules.UserMustExist(userToLogin);
        await _authBusinessRules.UserMustBeActive(userToLogin);
        await _authBusinessRules.UserPasswordMustMatch(userToLogin, loginRequest.Password);
        var createdAccessToken = await CreateAccessToken(userToLogin);
        LoginResponse loginResponse = new();
        loginResponse.AccessToken = createdAccessToken;
        return  loginResponse;
    }

    public async Task<RegisterResponse> Register(RegisterRequest registerRequest, string password)
    {
        await _authBusinessRules.UserWithSameEmailShouldNotExist(registerRequest.Email);

        User userToAdd = _mapper.Map<User>(registerRequest);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerRequest.Password, out passwordHash, out passwordSalt);
        userToAdd.PasswordHash = passwordHash;
        userToAdd.PasswordSalt = passwordSalt;
        userToAdd.Status = true;

        User addedUser = await _userService.Add(userToAdd);
        var createdAccessToken = await CreateAccessToken(addedUser);
        RegisterResponse registerResponse = new();
        registerResponse.AccessToken = createdAccessToken;
        return registerResponse;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        var claims = await _userOperationClaimService.GetClaims(user.Id);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }
}
