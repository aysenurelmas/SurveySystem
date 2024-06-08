using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfQuestionDal : EfRepositoryBase<Question, int, BaseDbContext>, IQuestionDal
{
    public EfQuestionDal(BaseDbContext context) : base(context)
    {
    }
}
