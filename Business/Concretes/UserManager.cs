using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Users;
using Business.Rules;
using Core.DataAccess.Security.Entities;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }
    public async Task<User> Add(User user)
    {
        User addedUser = await _userDal.AddAsync(user);
        return addedUser;
    }

    public async Task<User> GetByEmail(string email)
    {
        User? user = await _userDal.GetAsync(i => i.Email == email);
        return user;
    }

    public async Task<User> GetById(int id)
    {
        User? user = await _userDal.GetAsync(i => i.Id == id);
        return user;
    }

    public async Task Update(User user)
    {
        await _userDal.UpdateAsync(user);
    }
}
