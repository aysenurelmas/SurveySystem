using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IQuestionDal : IRepository<Question, int>, IAsyncRepository<Question, int>
{

}