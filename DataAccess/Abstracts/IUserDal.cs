using Core.DataAccess.Repositories;
using Core.DataAccess.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserDal : IRepository<User ,int> , IAsyncRepository<User ,int>
{
}
