using Business.Dtos.Users;
using Core.DataAccess.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    //Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);
    //Task<DeletedUserResponse> Delete(Guid id);
    public Task<User> GetByEmail(string email);
    public Task<User> GetById(int id);
    public Task<User> Add(User user);
    public Task Update(User user);
}
