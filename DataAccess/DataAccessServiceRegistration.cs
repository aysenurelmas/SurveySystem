using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataAccess.Contexts;
using DataAccess.Abstracts;
using DataAccess.Concretes;


namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SurveyDb")));

        services.AddScoped<ISurveyDal, EfSurveyDal>();
        services.AddScoped<IParticipationDal, EfParticipationDal>();
        services.AddScoped<IQuestionDal, EfQuestionDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
        services.AddScoped<IRefreshTokenDal, EfRefreshTokenDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();

        return services;
    }
}
