using Business.Abstracts;
using Business.Messages;
using Core.Business;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Security.Entities;
using Core.DataAccess.Security.Hashing;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserService _userService;
    public AuthBusinessRules(IUserService userService)
    {
        _userService = userService;
    }

    public async Task UserWithSameEmailShouldNotExist(string email)
    {
        User? user = await _userService.GetByEmail(email);
        if (user != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
    }
    public Task UserMustBeActive(User user)
    {
        if (user.Status == false)
            throw new BusinessException(BusinessMessages.UserNotActive);
        return Task.CompletedTask;
    }
    public Task UserMustExist(User? user)
    {
        if (user == null)
            throw new BusinessException(BusinessMessages.UserDontExists);
        return Task.CompletedTask;
    }
    public Task UserPasswordMustMatch(User? user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Şifre yanlış");

        return Task.CompletedTask;
    }
}