using Business;
using Core;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataAccess;
using Microsoft.OpenApi.Models;
using Core.DataAccess.Security.Encryption;
using ServiceStack.Configuration;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddCoreServices();
        builder.Services.AddBusinessServices();
        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                 {
                    new OpenApiSecurityScheme
                    {
                         Reference = new OpenApiReference
                         {
                             Type=ReferenceType.SecurityScheme,
                             Id="Bearer"
                         }
                    }, new string[] { }
                 }

            });
        });

        const string tokenOptionsConfigurationSection = "TokenOptions";
        TokenOptions? tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>();

        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.ConfigureCustomExceptionMiddleware();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}