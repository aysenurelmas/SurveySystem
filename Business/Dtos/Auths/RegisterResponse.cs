using Core.DataAccess.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Auths;

public class RegisterResponse
{
    public AccessToken AccessToken { get; set; }
}
