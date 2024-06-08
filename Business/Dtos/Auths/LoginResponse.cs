using Core.DataAccess.Security.JWT;

namespace Business.Dtos.Auths;

public class LoginResponse
{
    public AccessToken AccessToken { get; set; }
}