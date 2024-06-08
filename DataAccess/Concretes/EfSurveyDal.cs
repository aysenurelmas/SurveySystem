using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfSurveyDal : EfRepositoryBase<Survey, int, BaseDbContext>, ISurveyDal
{
    public EfSurveyDal(BaseDbContext context) : base(context)
    {
    }
}
