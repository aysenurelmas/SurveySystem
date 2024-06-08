using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IParticipationDal : IRepository<Participation, int>, IAsyncRepository<Participation, int>
{

}
